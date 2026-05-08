-- Them cot PhanHoi va NgayPhanHoi vao bang LienHe
-- Chay script nay 1 lan trong SQL Server Management Studio

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID(N'LienHe') AND name = N'PhanHoi'
)
BEGIN
    ALTER TABLE LienHe ADD PhanHoi NVARCHAR(MAX) NULL;
    PRINT 'Da them cot PhanHoi';
END
ELSE
    PRINT 'Cot PhanHoi da ton tai';

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID(N'LienHe') AND name = N'NgayPhanHoi'
)
BEGIN
    ALTER TABLE LienHe ADD NgayPhanHoi DATETIME NULL;
    PRINT 'Da them cot NgayPhanHoi';
END
ELSE
    PRINT 'Cot NgayPhanHoi da ton tai';
