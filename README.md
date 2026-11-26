# IN4533-BT02-0024419464

Họ tên: Hứa Quỳnh Như
MSSV: 0024419464

# Cách cài PostgreSQL

Cài trực tiếp từ installer EnterpriseDB (PostgreSQL 16), port mặc định 5432.
Tạo database bằng pgAdmin: chuột phải Databases -> Create -> Database -> đặt tên `eduhub`.

# Cách chạy

1. Mở pgAdmin, kết nối PostgreSQL 16, mở database `eduhub`.
2. Mở Query Tool, lần lượt mở và Execute 3 file:
   - `sql/01-schema.sql`
   - `sql/02-seed.sql`
   - `sql/03-queries.sql`
3. Chạy API:
cd src/EduHubApi
dotnet run
API lắng nghe ở `http://localhost:5294`.
4. Test API: xem `docs/requests.md`.

# Cấu trúc dự án

- `sql/` — 3 file SQL: schema, seed, queries
- `docs/api.md` — thiết kế REST API
- `docs/requests.md` — lệnh curl kiểm thử
- `docs/images/` — ảnh minh chứng
- `src/EduHubApi/` — mã Minimal API