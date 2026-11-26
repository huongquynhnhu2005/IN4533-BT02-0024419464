-- sql/03-queries.sql

-- (a) Ho ten thanh vien va ten khoa hoc cua cac phieu confirmed, sap xep theo ho ten
SELECT m.full_name, c.title
FROM registrations r
JOIN members m ON m.id = r.member_id
JOIN courses c ON c.id = r.course_id
WHERE r.status = 'confirmed'
ORDER BY m.full_name;

-- (b) So phieu dang ky cua tung khoa hoc, ke ca khoa chua co phieu nao
-- Dung LEFT JOIN de giu lai khoa chua co dang ky (COUNT = 0)
SELECT c.title, COUNT(r.id) AS so_dang_ky
FROM courses c
LEFT JOIN registrations r ON r.course_id = c.id
GROUP BY c.id, c.title
ORDER BY c.id;

-- (c) Cac thanh vien chua dang ky khoa nao
SELECT m.*
FROM members m
WHERE NOT EXISTS (
    SELECT 1 FROM registrations r WHERE r.member_id = m.id
);