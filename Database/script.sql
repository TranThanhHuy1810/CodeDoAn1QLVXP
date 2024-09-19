create database QLVXP
USE [QLVXP]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

GO
/****** Object:  Table [dbo].[DinhDangPhim]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinhDangPhim](
	[id] [varchar](50) NOT NULL,
	[idPhim] [varchar](50) NULL,
	[idLoaiManHinh] [varchar](50) NULL,
 CONSTRAINT [PK_DinhDangPhim] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[DiemTichLuy] [int] NULL,
	[SDT] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichChieu]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichChieu](
	[id] [varchar](50) NOT NULL,
	[ThoiGianChieu] [datetime] NULL,
	[idPhong] [varchar](50) NULL,
	[idDinhDang] [varchar](50) NULL,
	[GiaVe] [money] NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_LichChieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiManHinh]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiManHinh](
	[id] [varchar](50) NOT NULL,
	[TenMH] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiManHinh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNv] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanLoaiPhim]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanLoaiPhim](
	[idPhim] [varchar](50) NOT NULL,
	[idTheLoai] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PhanLoaiPhim] PRIMARY KEY CLUSTERED 
(
	[idPhim] ASC,
	[idTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phim]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phim](
	[id] [varchar](50) NOT NULL,
	[TenPhim] [nvarchar](50) NULL,
	[ThoiLuong] [float] NULL,
	[NgayKhoiChieu] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[SanXuat] [nvarchar](50) NULL,
	[DaoDien] [nvarchar](50) NULL,
	[NamSX] [int] NULL,
	[ApPhich] [image] NULL,
 CONSTRAINT [PK_Phim] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongChieu]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongChieu](
	[id] [varchar](50) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[idLoaiManHinh] [varchar](50) NULL,
	[SoChoNgoi] [int] NULL,
	[TinhTrang] [int] NULL,
	[SoHangGhe] [int] NULL,
	[SoGheMotHang] [int] NULL,
 CONSTRAINT [PK_PhongChieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Quyen] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[id] [varchar](50) NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ve]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ve](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idLichChieu] [varchar](50) NULL,
	[MaGheNgoi] [varchar](50) NULL,
	[idKhachHang] [varchar](50) NULL,
	[TrangThai] [int] NOT NULL,
	[TienBanVe] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ve] ADD  DEFAULT ('0') FOR [TrangThai]
GO
ALTER TABLE [dbo].[Ve] ADD  DEFAULT ('0') FOR [TienBanVe]
GO
ALTER TABLE [dbo].[DinhDangPhim]  WITH CHECK ADD  CONSTRAINT [FK_DinhDangPhim_LoaiManHinh] FOREIGN KEY([idLoaiManHinh])
REFERENCES [dbo].[LoaiManHinh] ([id])
GO
ALTER TABLE [dbo].[DinhDangPhim] CHECK CONSTRAINT [FK_DinhDangPhim_LoaiManHinh]
GO
ALTER TABLE [dbo].[DinhDangPhim]  WITH CHECK ADD  CONSTRAINT [FK_DinhDangPhim_Phim] FOREIGN KEY([idPhim])
REFERENCES [dbo].[Phim] ([id])
GO
ALTER TABLE [dbo].[DinhDangPhim] CHECK CONSTRAINT [FK_DinhDangPhim_Phim]
GO
ALTER TABLE [dbo].[LichChieu]  WITH CHECK ADD  CONSTRAINT [FK_LichChieu_DinhDangPhim] FOREIGN KEY([idDinhDang])
REFERENCES [dbo].[DinhDangPhim] ([id])
GO
ALTER TABLE [dbo].[LichChieu] CHECK CONSTRAINT [FK_LichChieu_DinhDangPhim]
GO
ALTER TABLE [dbo].[LichChieu]  WITH CHECK ADD  CONSTRAINT [FK_LichChieu_PhongChieu] FOREIGN KEY([idPhong])
REFERENCES [dbo].[PhongChieu] ([id])
GO
ALTER TABLE [dbo].[LichChieu] CHECK CONSTRAINT [FK_LichChieu_PhongChieu]
GO
ALTER TABLE [dbo].[PhanLoaiPhim]  WITH CHECK ADD  CONSTRAINT [FK_PhanLoaiPhim_Phim] FOREIGN KEY([idPhim])
REFERENCES [dbo].[Phim] ([id])
GO
ALTER TABLE [dbo].[PhanLoaiPhim] CHECK CONSTRAINT [FK_PhanLoaiPhim_Phim]
GO
ALTER TABLE [dbo].[PhanLoaiPhim]  WITH CHECK ADD  CONSTRAINT [FK_PhanLoaiPhim_TheLoai] FOREIGN KEY([idTheLoai])
REFERENCES [dbo].[TheLoai] ([id])
GO
ALTER TABLE [dbo].[PhanLoaiPhim] CHECK CONSTRAINT [FK_PhanLoaiPhim_TheLoai]
GO
ALTER TABLE [dbo].[PhongChieu]  WITH CHECK ADD  CONSTRAINT [FK_PhongChieu_LoaiManHinh] FOREIGN KEY([idLoaiManHinh])
REFERENCES [dbo].[LoaiManHinh] ([id])
GO
ALTER TABLE [dbo].[PhongChieu] CHECK CONSTRAINT [FK_PhongChieu_LoaiManHinh]
GO
ALTER TABLE [dbo].[Ve]  WITH CHECK ADD FOREIGN KEY([idKhachHang])
REFERENCES [dbo].[KhachHang] ([id])
GO
ALTER TABLE [dbo].[Ve]  WITH CHECK ADD FOREIGN KEY([idLichChieu])
REFERENCES [dbo].[LichChieu] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteTicketsByShowTimes]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_DeleteTicketsByShowTimes]
@idlichChieu VARCHAR(50)
AS
BEGIN
	DELETE FROM dbo.Ve
	WHERE idLichChieu = @idlichChieu
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetAllListShowTimes]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAllListShowTimes]
AS
BEGIN
	select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id
	order by l.ThoiGianChieu
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetCinema]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetCinema]
AS
BEGIN
	SELECT PC.id AS [Mã phòng], TenPhong AS [Tên phòng], TenMH AS [Tên màn hình], PC.SoChoNgoi AS [Số chỗ ngồi], PC.TinhTrang AS [Tình trạng], PC.SoHangGhe AS [Số hàng ghế], PC.SoGheMotHang AS [Ghế mỗi hàng]
	FROM dbo.PhongChieu AS PC, dbo.LoaiManHinh AS MH
	WHERE PC.idLoaiManHinh = MH.id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetCustomer]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetCustomer]
AS
BEGIN
	SELECT id AS [Mã khách hàng], HoTen AS [Họ tên],DiemTichLuy AS [Điểm tích lũy], SDT AS [SĐT]
	FROM dbo.KhachHang
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListFormatMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListFormatMovie]
AS
BEGIN
	SELECT DD.id AS [Mã định dạng], P.id AS [Mã phim], P.TenPhim AS [Tên phim], MH.id AS [Mã MH], MH.TenMH AS [Tên MH]
	FROM dbo.DinhDangPhim DD, Phim P, dbo.LoaiManHinh MH
	WHERE DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListGenreByMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListGenreByMovie]
@idPhim VARCHAR(50)
AS
BEGIN
	SELECT TL.id, TenTheLoai
	FROM dbo.PhanLoaiPhim PL, dbo.TheLoai TL
	WHERE idPhim = @idPhim AND PL.idTheLoai = TL.id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListShowTimesByFormatMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListShowTimesByFormatMovie]
@ID varchar(50), @Date Datetime
AS
BEGIN
	select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id
	and d.id = @ID and CONVERT(DATE, @Date) = CONVERT(DATE, l.ThoiGianChieu)
	order by l.ThoiGianChieu
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListShowTimesNotCreateTickets]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListShowTimesNotCreateTickets]
AS
BEGIN
	select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe, l.TrangThai
	from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc
	where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id and l.TrangThai = 0
	order by l.ThoiGianChieu
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetMovie]
AS
BEGIN
	SELECT id AS [Mã phim], TenPhim AS [Tên phim], ThoiLuong AS [Thời lượng], NgayKhoiChieu AS [Ngày khởi chiếu], NgayKetThuc AS [Ngày kết thúc], SanXuat AS [Sản xuất], DaoDien AS [Đạo diễn], NamSX AS [Năm SX], ApPhich AS [Ảnh]
	FROM dbo.Phim
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetRevenueByMovieAndDate]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetRevenueByMovieAndDate]
@idMovie VARCHAR(50), @fromDate date, @toDate date
AS
BEGIN
	SELECT P.TenPhim AS [Tên phim], CONVERT(DATE, LC.ThoiGianChieu) AS [Ngày chiếu], CONVERT(TIME(0),LC.ThoiGianChieu) AS [Giờ chiếu], COUNT(V.id) AS [Số vé đã bán], SUM(TienBanVe) AS [Tiền vé]
	FROM dbo.Ve AS V, dbo.LichChieu AS LC, dbo.DinhDangPhim AS DDP, Phim AS P
	WHERE V.idLichChieu = LC.id AND LC.idDinhDang = DDP.id AND DDP.idPhim = P.id AND V.TrangThai = 1 AND P.id = @idMovie AND LC.ThoiGianChieu >= @fromDate AND LC.ThoiGianChieu <= @toDate
	GROUP BY idLichChieu, P.TenPhim, LC.ThoiGianChieu
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetShowtime]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetShowtime]
AS
BEGIN
	SELECT LC.id AS [Mã lịch chiếu], LC.idPhong AS [Mã phòng], P.TenPhim AS [Tên phim], MH.TenMH AS [Màn hình], LC.ThoiGianChieu AS [Thời gian chiếu], LC.GiaVe AS [Giá vé]
	FROM dbo.LichChieu AS LC, dbo.DinhDangPhim AS DD, Phim AS P, dbo.LoaiManHinh AS MH
	WHERE LC.idDinhDang = DD.id AND DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetStaff]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetStaff]
AS
BEGIN
	SELECT MaNv AS [Mã nhân viên], HoTen AS [Họ tên], NgaySinh AS [Ngày sinh], DiaChi AS [Địa chỉ]
	FROM dbo.NhanVien
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertCinema]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_InsertCinema]
@idCinema VARCHAR(50), @tenPhong NVARCHAR(100), @idMH VARCHAR(50), @soChoNgoi INT, @tinhTrang INT, @soHangGhe INT, @soGheMotHang INT
AS
BEGIN
	INSERT dbo.PhongChieu ( id , TenPhong , idLoaiManHinh , SoChoNgoi , TinhTrang , SoHangGhe , SoGheMotHang)
	VALUES (@idCinema , @tenPhong , @idMH , @soChoNgoi , @tinhTrang , @soHangGhe , @soGheMotHang)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertCustomer]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertCustomer]
@idCus VARCHAR(50), @hoTen NVARCHAR(100), @sdt VARCHAR(100)
AS
BEGIN
	INSERT dbo.KhachHang (id, HoTen, DiemTichLuy, SDT)
	VALUES (@idCus, @hoTen, 0,@sdt )
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertFormatMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_InsertFormatMovie]
@id VARCHAR(50), @idPhim VARCHAR(50), @idLoaiManHinh VARCHAR(50)
AS
BEGIN
	INSERT dbo.DinhDangPhim ( id, idPhim, idLoaiManHinh )
	VALUES  ( @id, @idPhim, @idLoaiManHinh )
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertGenre]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertGenre]
@idGenre VARCHAR(50), @ten NVARCHAR(100)
AS
BEGIN
	INSERT dbo.TheLoai (id, TenTheLoai)
	VALUES  (@idGenre, @ten)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertMovie]
@id VARCHAR(50), @tenPhim NVARCHAR(100), @thoiLuong FLOAT, @ngayKhoiChieu DATE, @ngayKetThuc DATE, @sanXuat NVARCHAR(50), @daoDien NVARCHAR(100), @namSX INT, @apPhich IMAGE
AS
BEGIN
	INSERT dbo.Phim (id , TenPhim  , ThoiLuong , NgayKhoiChieu , NgayKetThuc , SanXuat , DaoDien , NamSX, ApPhich)
	VALUES (@id , @tenPhim  , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX, @apPhich)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertScreenType]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertScreenType]
@idScreenType VARCHAR(50), @ten NVARCHAR(100)
AS
BEGIN
	INSERT dbo.LoaiManHinh ( id, TenMH )
	VALUES  (@idScreenType, @ten)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertShowtime]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertShowtime]
@id VARCHAR(50), @idPhong VARCHAR(50), @idDinhDang VARCHAR(50), @thoiGianChieu DATETIME, @giaVe FLOAT
AS
BEGIN
	INSERT dbo.LichChieu ( id , idPhong , idDinhDang, ThoiGianChieu  , GiaVe , TrangThai )
	VALUES  ( @id , @idPhong , @idDinhDang, @thoiGianChieu  , @giaVe , 0 )
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertStaff]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertStaff]
@idStaff VARCHAR(50), @hoTen NVARCHAR(100), @ngaySinh date, @diaChi NVARCHAR(100)
AS
BEGIN
	INSERT dbo.NhanVien (MaNv, HoTen, NgaySinh, DiaChi)
	VALUES (@idStaff, @hoTen, @ngaySinh, @diaChi)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertTicketByShowTimes]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertTicketByShowTimes]
@idlichChieu VARCHAR(50), @maGheNgoi VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Ve
	(
		idLichChieu,
		MaGheNgoi,
		idKhachHang
	)
	VALUES
	(
		@idlichChieu,
		@maGheNgoi,
		NULL
	)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_TaiKhoan]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_TaiKhoan]
as
begin
	select TaiKhoan as[Tài Khoản],MatKhau as[Mật Khẩu],Email as[Email],Quyen[Quyền]
	from dbo.TaiKhoan
end

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateMovie]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateMovie]
@id VARCHAR(50), @tenPhim NVARCHAR(100), @thoiLuong FLOAT, @ngayKhoiChieu DATE, @ngayKetThuc DATE, @sanXuat NVARCHAR(50), @daoDien NVARCHAR(100), @namSX INT , @apPhich IMAGE
AS
BEGIN
	UPDATE dbo.Phim SET TenPhim = @tenPhim, ThoiLuong = @thoiLuong, NgayKhoiChieu = @ngayKhoiChieu, NgayKetThuc = @ngayKetThuc, SanXuat = @sanXuat, DaoDien = @daoDien, NamSX = @namSX, ApPhich = @apPhich WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateShowtime]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateShowtime]
@id VARCHAR(50), @idPhong VARCHAR(50), @idDinhDang VARCHAR(50), @thoiGianChieu DATETIME, @giaVe FLOAT
AS
BEGIN
	UPDATE dbo.LichChieu 
	SET idPhong = @idPhong, idDinhDang = @idDinhDang, ThoiGianChieu = @thoiGianChieu , GiaVe = @giaVe
	WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateStatusShowTimes]    Script Date: 05/06/2024 11:08:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_UpdateStatusShowTimes]
@idLichChieu NVARCHAR(50), @status int
AS
BEGIN
	UPDATE dbo.LichChieu
	SET TrangThai = @status
	WHERE id = @idLichChieu
END

GO
insert [dbo].[TaiKhoan]([TaiKhoan],[MatKhau],[Email],[Quyen])values ('admin','12345','admin@gmail.com','admin')