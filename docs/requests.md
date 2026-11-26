# Kiểm thử API bằng curl

API chạy ở http://localhost:5294.

# 1. Xem danh sách đăng ký của khoá học 2

Lệnh:

curl -i http://localhost:5294/api/v1/courses/2/registrations

Mã trạng thái dự kiến: 200 OK

# 2. Tạo đăng ký mới cho thành viên 4 vào khoá học 2

Lệnh:

curl -i -X POST http://localhost:5294/api/v1/courses/2/registrations -H "Content-Type: application/json" -d "{\"memberId\": 4}"

Mã trạng thái dự kiến: 201 Created

# 3. Xác nhận đăng ký có id = 7

Lệnh:

curl -i -X PATCH http://localhost:5294/api/v1/registrations/7 -H "Content-Type: application/json" -d "{\"status\": \"confirmed\"}"

Mã trạng thái dự kiến: 200 OK

# 4. Huỷ đăng ký có id = 7

Lệnh:

curl -i -X DELETE http://localhost:5294/api/v1/registrations/7

Mã trạng thái dự kiến: 204 No Content