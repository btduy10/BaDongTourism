-- Tao bang CaiDat luu noi dung cac trang co dinh
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CaiDat' AND xtype='U')
BEGIN
    CREATE TABLE CaiDat (
        Khoa        NVARCHAR(100)   NOT NULL PRIMARY KEY,
        GiaTri      NVARCHAR(MAX)   NULL,
        NhomCaiDat  NVARCHAR(50)    NOT NULL DEFAULT 'General',
        MoTa        NVARCHAR(200)   NULL
    );
    PRINT 'Da tao bang CaiDat';
END
ELSE
    PRINT 'Bang CaiDat da ton tai';

-- Chèn dữ liệu mặc định cho trang Giới Thiệu
MERGE CaiDat AS target
USING (VALUES
    -- Nhom GioiThieu
    ('gt_tieude_chinh',    N'Bãi Biển Ba Động – Vĩnh Long',           'GioiThieu', N'Tiêu đề chính trang Giới Thiệu'),
    ('gt_doan_1',          N'Bãi biển Ba Động thuộc phường Trường Long Hòa, tỉnh Vĩnh Long. Đây là bãi biển nằm ở phía Nam đồng bằng sông Cửu Long, cách trung tâm thành phố khoảng 55km và cách TP. Hồ Chí Minh khoảng 220km.',
                                                                       'GioiThieu', N'Đoạn văn 1 - Tổng quan'),
    ('gt_doan_2',          N'Bãi biển dài hơn 10km với bãi cát trắng phẳng lì, sóng êm và nước biển trong xanh. Đây là một trong số ít bãi biển ở miền Tây còn giữ được vẻ hoang sơ, nguyên thủy, chưa bị tác động nhiều bởi con người.',
                                                                       'GioiThieu', N'Đoạn văn 2 - Bãi biển'),
    ('gt_doan_3',          N'Ngoài vẻ đẹp thiên nhiên, Ba Động còn nổi tiếng với những đặc sản biển phong phú như cua Huỳnh Đế, ghẹ, sò huyết, và các loại hải sản tươi ngon khác.',
                                                                       'GioiThieu', N'Đoạn văn 3 - Đặc sản'),
    ('gt_hinh_chinh',      N'about-main.jpg',                          'GioiThieu', N'Tên file ảnh chính (trong Content/images/)'),
    ('gt_stat_1_so',       N'10km+',                                   'GioiThieu', N'Số liệu 1'),
    ('gt_stat_1_ten',      N'Chiều dài bờ biển',                      'GioiThieu', N'Nhãn số liệu 1'),
    ('gt_stat_2_so',       N'55km',                                    'GioiThieu', N'Số liệu 2'),
    ('gt_stat_2_ten',      N'Từ trung tâm thành phố',                 'GioiThieu', N'Nhãn số liệu 2'),
    -- Nhom Van Hoa
    ('vhls_tieude',        N'Vùng Đất Con Người',                     'GioiThieu', N'Tiêu đề phần Văn hóa'),
    ('vhls_doan_1',        N'Vùng đất Ba Động thuộc tỉnh Vĩnh Long (trước đây là tỉnh Trà Vinh) có đông đồng bào Khmer sinh sống, với nhiều ngôi chùa đặc trưng kiến trúc Khmer nổi tiếng. Vùng Duyên Hải nói chung và Ba Động nói riêng còn gìn giữ nhiều phong tục, lễ hội truyền thống đặc sắc.',
                                                                       'GioiThieu', N'Đoạn văn Văn hóa 1'),
    ('vhls_doan_2',        N'Lễ hội Nghinh Ông (Lễ cúng cá ông) được tổ chức hằng năm vào tháng 5 âm lịch là lễ hội lớn nhất của ngư dân địa phương, thu hút hàng nghìn người tham dự.',
                                                                       'GioiThieu', N'Đoạn văn Văn hóa 2'),
    ('vhls_doan_3',        N'Làng nghề đan lát từ lá buông, nghề làm bánh tét truyền thống... là những nét văn hóa đặc sắc cần được bảo tồn và phát huy.',
                                                                       'GioiThieu', N'Đoạn văn Văn hóa 3'),
    ('vhls_hinh',          N'culture.jpg',                             'GioiThieu', N'Tên file ảnh văn hóa (trong Content/images/)'),
    -- Nhom Di chuyen
    ('dichuy_o_to',        N'Đi xe ô tô theo hướng QL1A → TP. Vĩnh Long → QL53 → QL54 → phường Trường Long Hòa → Ba Động. Khoảng cách ~220km từ TP.HCM, thời gian ~4 tiếng.',
                                                                       'GioiThieu', N'Hướng dẫn đi xe ô tô'),
    ('dichuy_xe_khach',    N'Từ bến xe Miền Tây (HCM) đi xe khách đến TP. Vĩnh Long, sau đó đi xe máy ôm hoặc thuê xe tự lái ~55km đến Ba Động.',
                                                                       'GioiThieu', N'Hướng dẫn đi xe khách'),
    ('dichuy_xe_may',      N'Rất phù hợp cho những ai thích phượt. Đường đi tương đối bằng phẳng, phong cảnh đẹp dọc đường. Có thể dừng nghỉ tại nhiều điểm thú vị.',
                                                                       'GioiThieu', N'Hướng dẫn đi xe máy')
) AS source (Khoa, GiaTri, NhomCaiDat, MoTa)
ON target.Khoa = source.Khoa
WHEN NOT MATCHED THEN
    INSERT (Khoa, GiaTri, NhomCaiDat, MoTa)
    VALUES (source.Khoa, source.GiaTri, source.NhomCaiDat, source.MoTa);

PRINT 'Da chen du lieu mac dinh cho trang Gioi Thieu';
