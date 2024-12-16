CREATE DATABASE CLBTinHoc_64131060;
GO
USE CLBTinHoc_64131060;
GO

-- Tạo bảng VaiTro (Lưu thông tin vai trò của người dùng)
CREATE TABLE VaiTro (
    MaVaiTro NVARCHAR(50) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL
);

-- Tạo bảng ThanhVien (Lưu thông tin thành viên)
CREATE TABLE ThanhVien (
    MaThanhVien NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    MaVaiTro NVARCHAR(50) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);

-- Tạo bảng SuKien (Lưu thông tin sự kiện)
CREATE TABLE SuKien (
    MaSuKien NVARCHAR(50) PRIMARY KEY,
    TenSuKien NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(MAX),
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME NOT NULL,
    NguoiToChuc NVARCHAR(50) NOT NULL,
    FOREIGN KEY (NguoiToChuc) REFERENCES ThanhVien(MaThanhVien)
);

CREATE TABLE ThanhVienSuKien (
    MaSuKien NVARCHAR(50) NOT NULL,
    MaThanhVien NVARCHAR(50) NOT NULL,
    NgayDangKy DATETIME DEFAULT GETDATE(),
	PRIMARY KEY (MaSuKien, MaThanhVien),
    FOREIGN KEY (MaSuKien) REFERENCES SuKien(MaSuKien),
    FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien)
);

-- Tạo bảng NhomHocTap (Lưu thông tin nhóm học tập)
CREATE TABLE NhomHocTap (
    MaNhom NVARCHAR(50) PRIMARY KEY,
    TenNhom NVARCHAR(100) NOT NULL,
    TroGiang NVARCHAR(50) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
	MoTa NVARCHAR(MAX),
    FOREIGN KEY (TroGiang) REFERENCES ThanhVien(MaThanhVien)
);

-- Tạo bảng ThanhVienNhom (Lưu thông tin thành viên tham gia nhóm học tập)
CREATE TABLE ThanhVienNhom (
    MaNhom NVARCHAR(50) NOT NULL,
    MaThanhVien NVARCHAR(50) NOT NULL,
    NgayThamGia DATETIME DEFAULT GETDATE(),
	PRIMARY KEY (MaNhom, MaThanhVien),
    FOREIGN KEY (MaNhom) REFERENCES NhomHocTap(MaNhom),
    FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien)
);

-- Tạo bảng DiemDanh (Lưu thông tin điểm danh theo ngày)
CREATE TABLE DiemDanh (
    MaDiemDanh INT PRIMARY KEY IDENTITY(1,1),
    MaNhom NVARCHAR(50) NOT NULL,
    MaThanhVien NVARCHAR(50) NOT NULL,
    NgayDiemDanh DATE NOT NULL, -- Thêm trường ngày điểm danh
    TrangThai NVARCHAR(50) NOT NULL,
	GhiChu NVARCHAR(MAX),
    FOREIGN KEY (MaNhom) REFERENCES NhomHocTap(MaNhom),
    FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien),
);

-- Tạo bảng BaiDang (Lưu thông tin bài đăng)
CREATE TABLE BaiDang (
    MaBaiDang NVARCHAR(50) PRIMARY KEY NOT NULL,
    TieuDe NVARCHAR(MAX) NOT NULL,
	Anh NVARCHAR(100) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    TacGia NVARCHAR(50) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (TacGia) REFERENCES ThanhVien(MaThanhVien)
);

-- Tạo bảng BaoCao (Lưu thông tin báo cáo)
CREATE TABLE BaoCao (
    MaBaoCao INT PRIMARY KEY IDENTITY(1,1),
    TieuDe NVARCHAR(100) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    NopBoi NVARCHAR(50) NOT NULL,
    NgayNop DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (NopBoi) REFERENCES ThanhVien(MaThanhVien)
);

-- Thêm dữ liệu mẫu vào bảng VaiTro
INSERT INTO VaiTro (MaVaiTro,TenVaiTro) VALUES 
(N'TVCN',N'Chủ nhiệm'), 
(N'TVTG' ,N'Thành viên trợ giảng'), 
(N'TV' ,N'Thành viên thường');

-- Thêm dữ liệu mẫu vào bảng ThanhVien
INSERT INTO ThanhVien (MaThanhVien , HoTen, Email, MatKhau, MaVaiTro) VALUES
(N'64132127', N'Trần Thanh Thái', 'thai.tt.64cntt@ntu.edu.vn', '123', N'TVCN'),
(N'64131060', N'Phạm Tuấn Kiệt', 'kiet.pt.64cntt@ntu.edu.vn', '123', N'TVTG'),
(N'64132677', N'Vương Minh Trí', 'tri.vm.64cntt@ntu.edu.vn', '123', N'TVTG'),
(N'64130378', N'Trần Diệp Hồng Dung', 'dung.tdh.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132848', N'Trịnh Ngọc Tuấn', 'tuan.tn.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130493', N'Cao Linh Hà', 'ha.cl.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130152', N'Nguyễn Hồ Thanh Bình', 'binh.nht.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131973', N'Nguyễn Hiểu Quyên', 'quyen.nh.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132409', N'Vĩnh Thuận', 'thuan.v.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132902', N'Võ Văn Uy', 'uy.vv.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132079', N'Nguyễn Quốc Kỳ Tài', 'tai.nqk.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131375', N'Huỳnh Xuân Nam', 'nam.hx.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131236', N'Lê Văn Lương', 'luong.lv.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131228', N'Nguyễn Đỗ Thiên Luân', 'luan.ndt.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131209', N'Huỳnh Ngọc Long', 'long.hn.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131003', N'Đặng Nguyến Đăng Khoa', 'khoa.dnd.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130939', N'Lê Ngọc Khải', 'khai.ln.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130227', N'Phạm Mạnh Cường', 'cuong.pm.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130729', N'Lê Việt Hoàng', 'hoang.lv.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130262', N'Trần Hoàng Đạo', 'dao.th.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131858', N'Nguyễn Thành Phước', 'phuoc.nt.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132058', N'Nguyễn Hải Sơn', 'son.nh.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132800', N'Nguyễn Hoàng Minh Tú', 'tu.nhm.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130134', N'Trần Lương Gia Bảo', 'bao.tlg.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64130848', N'Lê Quang Huy', 'huy.lq.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64131537', N'Nguyễn Đình Nguyên', 'nguyen.nd.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132295', N'Nguyễn Diệp Trường Thịnh', 'thinh.ndt.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132319', N'Nguyễn Hữu Thọ', 'tho.nh.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132534', N'Huỳnh Nguyễn Thương Tín', 'tin.hnt.64cntt@ntu.edu.vn', '123', N'TV'),
(N'64132201', N'Võ Văn Thành', 'thanh.vv.64cntt@ntu.edu.vn', '123', N'TV');

-- Thêm dữ liệu mẫu vào bảng SuKien
INSERT INTO SuKien (MaSuKien, TenSuKien, MoTa, NgayBatDau, NgayKetThuc, NguoiToChuc) VALUES
(N'SK001', N'Workshop Kỹ năng', N'Buổi workshop về kỹ năng làm việc nhóm.', '2024-12-01', '2024-12-01', N'64132127'),
(N'SK002', N'Hackathon', N'Cuộc thi lập trình kéo dài 48 giờ.', '2024-12-15', '2024-12-17', N'64132127'),
(N'SK003', N'Chào đón Tân Sinh Viên', N'Hoạt động chào đón và định hướng.', '2024-11-30', '2024-11-30', N'64132127'),
(N'SK004', N'Buổi học Python cơ bản', N'Dành cho người mới bắt đầu học lập trình Python.', '2024-12-05', '2024-12-05', N'64131060'),
(N'SK005', N'Seminar Công nghệ', N'Thảo luận về các xu hướng công nghệ mới.', '2024-12-10', '2024-12-10', N'64132677'),
(N'SK006', N'Ngày Nhà Giáo Việt Nam 20 - 11', N'Chào mừng ngày nhà giáo Việt Nam', '2024-11-20', '2024-11-20', N'64132127');

-- Thêm dữ liệu mẫu vào bảng ThanhVienSuKien
INSERT INTO ThanhVienSuKien (MaSuKien, MaThanhVien) VALUES
(N'SK001', N'64132409'),
(N'SK001', N'64132534'),
(N'SK001', N'64131209'),
(N'SK001', N'64132201'),
(N'SK001', N'64130134'),
(N'SK002', N'64130493'),
(N'SK002', N'64131973'),
(N'SK002', N'64132079'),
(N'SK002', N'64130152'),
(N'SK002', N'64130939'),
(N'SK003', N'64130227'),
(N'SK003', N'64131003'),
(N'SK003', N'64131375'),
(N'SK003', N'64132848'),
(N'SK003', N'64130378'),
(N'SK004', N'64132409'),
(N'SK004', N'64132534'),
(N'SK004', N'64132319'),
(N'SK004', N'64132201'),
(N'SK004', N'64130134'),
(N'SK005', N'64130493'),
(N'SK005', N'64131973'),
(N'SK005', N'64132079'),
(N'SK005', N'64130152'),
(N'SK005', N'64130939'),
(N'SK006', N'64130227'),
(N'SK006', N'64131003'),
(N'SK006', N'64131375'),
(N'SK006', N'64132848'),
(N'SK006', N'64130378');

-- Thêm dữ liệu mẫu vào bảng NhomHocTap
INSERT INTO NhomHocTap (MaNhom, TenNhom, TroGiang, MoTa) VALUES
(N'MNLT', N'Nhóm Nhập môn lập trình', N'64132127',N'Nhóm học tập về lập trình căn bản.'),
(N'KTLT', N'Nhóm Kỹ thuật lập trình', N'64132677',N'Nhóm học tập về lập trình nâng cao.'),
(N'PTUDW', N'Nhóm Web', N'64131060' , N'Nhóm phát triển ứng dụng Web.'),
(N'MMT', N'Nhóm Mạng máy tính', N'64132127', N'Nghiên cứu về mạng máy tính.');

--Thêm dữ liệu mẫu vào bảng ThanhVienNhom
INSERT INTO ThanhVienNhom (MaNhom, MaThanhVien) VALUES
(N'MNLT', N'64130378'),
(N'MNLT', N'64132848'),
(N'MNLT', N'64130493'),
(N'MNLT', N'64130152'),
(N'MNLT', N'64131973'),
(N'MNLT', N'64132409'),
(N'KTLT', N'64130378'),
(N'KTLT', N'64131375'),
(N'KTLT', N'64130493'),
(N'KTLT', N'64132201'),
(N'KTLT', N'64131209'),
(N'KTLT', N'64132800'),
(N'PTUDW', N'64130134'),
(N'PTUDW', N'64131236'),
(N'PTUDW', N'64130493'),
(N'PTUDW', N'64131228'),
(N'PTUDW', N'64131209'),
(N'PTUDW', N'64132534'),
(N'MMT', N'64131003'),
(N'MMT', N'64130848'),
(N'MMT', N'64130939'),
(N'MMT', N'64131973'),
(N'MMT', N'64132058'),
(N'MMT', N'64131858');

-- Thêm dữ liệu mẫu vào bảng DiemDanh
INSERT INTO DiemDanh (MaNhom, MaThanhVien, NgayDiemDanh, TrangThai, GhiChu) VALUES
(N'MNLT', N'64130378', '2024-10-6', N'Có mặt',N''),
(N'MNLT', N'64132848', '2024-10-6', N'Vắng mặt',N'Lý do vắng: Có việc đột xuất'),
(N'MNLT', N'64130493', '2024-10-6', N'Có mặt',N''),
(N'MNLT', N'64130152', '2024-10-6', N'Có mặt',N''),
(N'MNLT', N'64131973', '2024-10-6', N'Có mặt',N''),
(N'MNLT', N'64132409', '2024-10-6', N'Có mặt',N''),
(N'KTLT', N'64130378', '2024-10-10', N'Có mặt',N''),
(N'KTLT', N'64131375', '2024-10-10', N'Vắng mặt',N'Lý do vắng: Bệnh sốt'),
(N'KTLT', N'64130493', '2024-10-10', N'Có mặt',N''),
(N'KTLT', N'64132201', '2024-10-10', N'Có mặt',N''),
(N'KTLT', N'64131209', '2024-10-10', N'Có mặt',N''),
(N'KTLT', N'64132800', '2024-10-10', N'Có mặt',N''),
(N'PTUDW', N'64130134', '2024-10-5', N'Có mặt',N''),
(N'PTUDW', N'64131236', '2024-10-5', N'Vắng mặt',N'Lý do vắng: trùng lịch học'),
(N'PTUDW', N'64130493', '2024-10-5', N'Có mặt',N''),
(N'PTUDW', N'64131228', '2024-10-5', N'Có mặt',N''),
(N'PTUDW', N'64131209', '2024-10-5', N'Có mặt',N''),
(N'PTUDW', N'64132534', '2024-10-5', N'Có mặt',N''),
(N'MMT', N'64131003', '2024-10-7', N'Có mặt',N''),
(N'MMT', N'64130848', '2024-10-7', N'Vắng mặt',N'Lý do vắng: trùng lịch thi'),
(N'MMT', N'64130939', '2024-10-7', N'Có mặt',N''),
(N'MMT', N'64131973', '2024-10-7', N'Có mặt',N''),
(N'MMT', N'64132058', '2024-10-7', N'Có mặt',N''),
(N'MMT', N'64131858', '2024-10-7', N'Có mặt',N'');

-- Thêm dữ liệu mẫu vào bảng BaiDang
INSERT INTO BaiDang (MaBaiDang ,TieuDe ,Anh , NoiDung, TacGia) VALUES
(N'BD001', N'Thành viên mới và 10 vạn câu hỏi cần giải đáp', N'BD001.jpg', N'Thành viên mới và 10 vạn câu hỏi cần giải đáp', N'64132127'),
(N'BD002', N'THÔNG BÁO TỪ CLB TIN HỌC', N'B002.jpg', N'Thông báo lịch học', N'64132127'),
(N'BD003', N'CHÚC MỪNG NGÀY PHỤ NỮ VIỆT NAM 20/10', N'B003.jpg', N'Nhân dịp ngày 20/10 – Ngày Phụ nữ Việt Nam, Câu lạc bộ Tin học xin gửi lời chúc tốt đẹp nhất đến những nụ hồng IT đáng iu. Chúc các bạn luôn xinh đẹp, hạnh phúc, tự tin và thành công trong học tập, công việc cũng như trong cuộc sống.', N'64132127'),
(N'BD004', N'CUỘC THI CHÀO MỪNG NGÀY NHÀ GIÁO VIỆT NAM 10/11', N'BD0004.jpg',N'Cuộc thi chào mừng ngày nhà giáo Việt Nam 20/11', N'64131060');

-- Thêm dữ liệu mẫu vào bảng BaoCao
INSERT INTO BaoCao (TieuDe, NoiDung, NopBoi) VALUES
(N'Báo cáo Workshop Kỹ năng', N'Tổng kết buổi workshop ngày 01/12.', N'64132127'),
(N'Báo cáo cuộc thi Hackathon', N'Báo cáo kết quả cuộc thi Hackathon.', N'64132127'),
(N'Báo cáo chào đón Tân Sinh Viên', N'Báo cáo Hoạt động chào đón và định hướng.', N'64132127'),
(N'Báo cáo buổi học Python cơ bản', N'Báo cáo kết quả buổi học Python cơ bản.', N'64131060'),
(N'Báo cáo Seminar Công nghệ', N'Báo cáo thảo luận về các xu hướng công nghệ mới.', N'64132677'),
(N'Báo cáo cuộc thi chào mừng ngày giáo Việt Nam', N'Báo cáo kết quả cuộc thi chào mừng ngày nhà giáo Việt Nam.', N'64132127');



select * from VaiTro
select * from ThanhVien
select * from SuKien
select * from ThanhVienSuKien
select * from NhomHocTap
select * from ThanhVienNhom
select * from DiemDanh
select * from BaiDang
select * from BaoCao

CREATE PROCEDURE SuKien_TimKiem
    @maSuKien NVARCHAR(50) = '',
    @tenSuKien NVARCHAR(100) = ''
AS
BEGIN
    SELECT *
    FROM SuKien
    WHERE (@maSuKien = '' OR MaSuKien LIKE '%' + @maSuKien + '%')
      AND (@tenSuKien = '' OR TenSuKien LIKE '%' + @tenSuKien + '%')
END

CREATE PROCEDURE ThanhVien_TimKiem
    @HoTen NVARCHAR(100) = '',
    @MaThanhVien NVARCHAR(50) = ''
AS
BEGIN
    SELECT TV.MaThanhVien, TV.HoTen, TV.Email, TV.MatKhau,TV.NgayTao,TV.MaVaiTro
    FROM ThanhVien TV
    INNER JOIN VaiTro VT ON TV.MaVaiTro = VT.MaVaiTro
    WHERE (@HoTen = '' OR TV.HoTen LIKE '%' + @HoTen + '%')
      AND (@MaThanhVien = '' OR TV.MaThanhVien LIKE '%' + @MaThanhVien + '%')
END
