using EduHubApi.Data;
using EduHubApi.Models;
using Npgsql;

namespace EduHubApi.Endpoints;

public static class RegistrationEndpoints
{
    public static void MapRegistrationEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/courses/{courseId:int}/registrations", async (int courseId, NpgsqlDataSource db) =>
        {
            await using var conn = await db.OpenConnectionAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, member_id, course_id, status FROM registrations WHERE course_id = @cid",
                conn);
            cmd.Parameters.AddWithValue("cid", courseId);

            await using var reader = await cmd.ExecuteReaderAsync();
            var list = new List<Registration>();
            while (await reader.ReadAsync())
            {
                list.Add(new Registration
                {
                    Id = reader.GetInt32(0),
                    MemberId = reader.GetInt32(1),
                    CourseId = reader.GetInt32(2),
                    Status = reader.GetString(3)
                });
            }
            return Results.Ok(list);
        });

        app.MapPost("/api/v1/courses/{courseId:int}/registrations", async (int courseId, CreateRegistrationRequest req, NpgsqlDataSource db) =>
        {
            await using var conn = await db.OpenConnectionAsync();
            await using var cmd = new NpgsqlCommand(
                "INSERT INTO registrations (member_id, course_id, status) VALUES (@mid, @cid, 'pending') RETURNING id, member_id, course_id, status",
                conn);
            cmd.Parameters.AddWithValue("mid", req.MemberId);
            cmd.Parameters.AddWithValue("cid", courseId);

            try
            {
                await using var reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                var created = new Registration
                {
                    Id = reader.GetInt32(0),
                    MemberId = reader.GetInt32(1),
                    CourseId = reader.GetInt32(2),
                    Status = reader.GetString(3)
                };
                return Results.Created($"/api/v1/registrations/{created.Id}", created);
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                return Results.Problem(
                    title: "Trung dang ky",
                    detail: "Thanh vien nay da dang ky khoa hoc nay roi.",
                    statusCode: 409,
                    type: "https://example.com/probs/duplicate-registration");
            }
        });
    }
}