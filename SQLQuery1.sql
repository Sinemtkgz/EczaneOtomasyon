
CREATE PROCEDURE Sp_ekle
(@HastaTC varchar(15),@HastaAdi varchar(50),@HastaSoyadi varchar(50),@IlacBarkod varchar(20),@IlacAdi varchar(50),@IlacAdedi tinyint,@VerilisTarihi date,@KullanýmAmaci varchar(50), @Fiyat decimal(6,2),@TelefonNo varchar(15))
AS
BEGIN
INSERT INTO BilgiTablosu (HastaTC,HastaAdi,HastaSoyadi,IlacBarkod,IlacAdi,IlacAdedi,VerilisTarihi,KullanimAmaci,Fiyat,TelefonNo)
VALUES (@HastaTC,@HastaAdi,@HastaSoyadi,@IlacBarkod,@IlacAdi,@IlacAdedi,@VerilisTarihi,@KullanýmAmaci,@Fiyat,@TelefonNo);
END


CREATE PROCEDURE Sp_guncelle 
(@Id int,@HastaTC varchar(15),@HastaAdi varchar(50),@HastaSoyadi varchar(50),@IlacBarkod varchar(20),@IlacAdi varchar(50),@IlacAdedi tinyint,@VerilisTarihi date,@KullanýmAmaci varchar(50),@Fiyat decimal(6,2),@TelefonNo varchar(15))
AS
BEGIN
UPDATE BilgiTablosu SET HastaTC=@HastaTC,HastaAdi=@HastaAdi,HastaSoyadi=@HastaSoyadi,IlacBarkod=@IlacBarkod,IlacAdi=@IlacAdi,IlacAdedi=@IlacAdedi,VerilisTarihi=@VerilisTarihi,KullanimAmaci=@KullanýmAmaci,Fiyat=@Fiyat,TelefonNo=@TelefonNo WHERE Id=@Id;
END


CREATE PROCEDURE Sp_sil
(@HastaTC varchar(50))
AS
BEGIN
DELETE FROM BilgiTablosu WHERE @HastaTC=HastaTC;
END


CREATE PROCEDURE Sp_ara
(@HastaTC varchar(50))
AS
BEGIN
SELECT * FROM BilgiTablosu WHERE HastaTC like '%'+@HastaTC+'%'
END