-- sql/02-seed.sql
INSERT INTO members (full_name, email) VALUES
('Nguyen Van An', 'an@gmail.com'),
('Tran Thi Binh', 'binh@gmail.com'),
('Le Van Cuong', 'cuong@gmail.com'),
('Pham Thi Dung', 'dung@gmail.com');

INSERT INTO courses (title, capacity) VALUES
('Lap trinh Back End', 40),
('Co so du lieu', 35),
('Phat trien Web', 50);

INSERT INTO registrations (member_id, course_id, status) VALUES
(1, 1, 'confirmed'),
(1, 2, 'pending'),
(2, 1, 'cancelled'),
(2, 3, 'confirmed'),
(3, 2, 'confirmed'),
(3, 3, 'pending');
-- member 4 (Pham Thi Dung) chua dang ky khoa nao