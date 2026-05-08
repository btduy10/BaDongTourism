-- =============================================
-- SEED: Du lieu mac dinh cho nhom TrangChu
-- Chay trong SSMS sau khi da co bang CaiDat
-- =============================================

USE BaDongTourism;
GO

MERGE CaiDat AS target
USING (VALUES
    -- Phan "Ve Chung Toi"
    ('tc_subtitle',  N'Về Chúng Tôi',                         'TrangChu', N'Nhan phu section'),
    ('tc_tieude',    N'Viên Ngọc Xanh' + CHAR(10) + N'Của Trà Vinh',
                                                               'TrangChu', N'Tieu de chinh (moi dong = 1 dong)'),
    ('tc_doan_1',    N'Bãi biển Ba Động thuộc xã Trường Long Hòa, huyện Duyên Hải, tỉnh Trà Vinh – nằm cách TP. Trà Vinh khoảng 50km về phía Nam. Đây là một trong những bãi biển hoang sơ, đẹp và ít bị tác động nhất ở miền Tây Nam Bộ.',
                                                               'TrangChu', N'Doan van 1'),
    ('tc_doan_2',    N'Với bờ biển dài hơn 10km, cát trắng mịn, sóng êm và không khí trong lành, Ba Động đang dần trở thành điểm đến hấp dẫn cho những du khách muốn tìm về thiên nhiên nguyên sơ.',
                                                               'TrangChu', N'Doan van 2'),
    ('tc_badge_so',  N'Top 10',                               'TrangChu', N'Badge so/tieu de'),
    ('tc_badge_ten', N'Bãi biển đẹp VN',                     'TrangChu', N'Badge mo ta'),
    ('tc_hinh',      N'',                                     'TrangChu', N'Hinh anh chinh (de trong = dung mac dinh)'),
    -- 4 dac diem
    ('tc_feat1_ten', N'Biển Sạch',                            'TrangChu', N'Dac diem 1 ten'),
    ('tc_feat1_mo',  N'Nước biển trong xanh, ít ô nhiễm',     'TrangChu', N'Dac diem 1 mo ta'),
    ('tc_feat2_ten', N'Sinh Thái',                            'TrangChu', N'Dac diem 2 ten'),
    ('tc_feat2_mo',  N'Rừng ngập mặn đa dạng',               'TrangChu', N'Dac diem 2 mo ta'),
    ('tc_feat3_ten', N'Hải Sản',                              'TrangChu', N'Dac diem 3 ten'),
    ('tc_feat3_mo',  N'Cua Huỳnh Đế nổi tiếng',              'TrangChu', N'Dac diem 3 mo ta'),
    ('tc_feat4_ten', N'Thân Thiện',                           'TrangChu', N'Dac diem 4 ten'),
    ('tc_feat4_mo',  N'Người dân hiếu khách',                 'TrangChu', N'Dac diem 4 mo ta'),
    -- Thong ke (Stats bar)
    ('stat1_so',     N'10',                                   'TrangChu', N'Stat 1 so dem'),
    ('stat1_hauTo',  N'km+',                                  'TrangChu', N'Stat 1 hau to'),
    ('stat1_nhan',   N'Chiều dài bãi biển',                  'TrangChu', N'Stat 1 nhan'),
    ('stat2_so',     N'50',                                   'TrangChu', N'Stat 2 so dem'),
    ('stat2_hauTo',  N'+',                                    'TrangChu', N'Stat 2 hau to'),
    ('stat2_nhan',   N'Tour du lịch',                         'TrangChu', N'Stat 2 nhan'),
    ('stat3_so',     N'30',                                   'TrangChu', N'Stat 3 so dem'),
    ('stat3_hauTo',  N'+',                                    'TrangChu', N'Stat 3 hau to'),
    ('stat3_nhan',   N'Cơ sở lưu trú',                       'TrangChu', N'Stat 3 nhan'),
    ('stat4_so',     N'100000',                               'TrangChu', N'Stat 4 so dem'),
    ('stat4_hauTo',  N'+',                                    'TrangChu', N'Stat 4 hau to'),
    ('stat4_nhan',   N'Lượt khách/năm',                      'TrangChu', N'Stat 4 nhan'),
    -- CTA
    ('cta_tieude',   N'Sẵn Sàng Khám Phá Ba Động?',          'TrangChu', N'CTA tieu de'),
    ('cta_mota',     N'Liên hệ ngay để được tư vấn và đặt tour với giá tốt nhất!',
                                                               'TrangChu', N'CTA mo ta'),
    ('cta_btn1',     N'Đặt Tour Ngay',                        'TrangChu', N'CTA nut 1 noi dung'),
    ('cta_btn1_link',N'DatTour.aspx',                         'TrangChu', N'CTA nut 1 link'),
    ('cta_btn2',     N'Liên Hệ',                              'TrangChu', N'CTA nut 2 noi dung'),
    ('cta_btn2_link',N'LienHe.aspx',                          'TrangChu', N'CTA nut 2 link')
) AS source (Khoa, GiaTri, NhomCaiDat, MoTa)
ON target.Khoa = source.Khoa
WHEN MATCHED THEN
    UPDATE SET GiaTri = source.GiaTri, NhomCaiDat = source.NhomCaiDat, MoTa = source.MoTa
WHEN NOT MATCHED THEN
    INSERT (Khoa, GiaTri, NhomCaiDat, MoTa)
    VALUES (source.Khoa, source.GiaTri, source.NhomCaiDat, source.MoTa);

PRINT N'Da seed xong du lieu TrangChu (' + CAST(@@ROWCOUNT AS VARCHAR) + N' rows).';
GO
