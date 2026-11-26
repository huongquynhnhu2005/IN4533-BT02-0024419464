# Thiết kế REST API cho registrations

# 1. Xem danh sách đăng ký của một khoá học

- Method: GET
- URI: /api/v1/courses/{courseId}/registrations
- Mã thành công: 200 OK
- Mã lỗi có thể gặp: 404 Not Found (khoá học không tồn tại)

# 2. Tạo đăng ký

- Method: POST
- URI: /api/v1/courses/{courseId}/registrations
- Mã thành công: 201 Created
- Mã lỗi có thể gặp:
  - 400 Bad Request (thiếu memberId hoặc memberId không hợp lệ)
  - 404 Not Found (khoá học không tồn tại)
  - 409 Conflict (thành viên đã đăng ký khoá học này rồi)

# 3. Xác nhận đăng ký

- Method: PATCH
- URI: /api/v1/registrations/{id}
- Mã thành công: 200 OK
- Mã lỗi có thể gặp:
  - 404 Not Found (không tìm thấy phiếu đăng ký)
  - 409 Conflict (trạng thái hiện tại không cho phép xác nhận, ví dụ đã cancelled)

# 4. Huỷ đăng ký

- Method: DELETE
- URI: /api/v1/registrations/{id}
- Mã thành công: 204 No Content
- Mã lỗi có thể gặp: 404 Not Found (không tìm thấy phiếu đăng ký)

# 5. JSON mẫu cho chức năng tạo đăng ký

# Request

POST /api/v1/courses/2/registrations
Content-Type: application/json

{
  "memberId": 3
}

# Response thành công — 201 Created

{
  "id": 7,
  "memberId": 3,
  "courseId": 2,
  "status": "pending"
}

# Response lỗi trùng đăng ký — 409 Conflict (Problem Details theo RFC 9457)

Content-Type: application/problem+json

{
  "type": "https://example.com/probs/duplicate-registration",
  "title": "Trùng đăng ký",
  "status": 409,
  "detail": "Thành viên này đã đăng ký khoá học này rồi.",
  "instance": "/api/v1/courses/2/registrations"
}