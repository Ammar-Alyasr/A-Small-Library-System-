-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 25 Ara 2015, 12:18:25
-- Sunucu sürümü: 5.6.17
-- PHP Sürümü: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Veritabanı: `library`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kitaplar`
--

CREATE TABLE IF NOT EXISTS `kitaplar` (
  `kitapin_numarasi` int(20) NOT NULL AUTO_INCREMENT,
  `kitapin_ismi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `kitapin_yayin_evi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `kitapin_sayfa_sayisi` int(20) NOT NULL,
  `kitapin_turu` varchar(20) COLLATE utf8mb4_turkish_ci NOT NULL,
  `yazarin_idisi` int(32) DEFAULT NULL,
  PRIMARY KEY (`kitapin_numarasi`),
  UNIQUE KEY `kitapin_numarasi` (`kitapin_numarasi`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci AUTO_INCREMENT=8988 ;

--
-- Tablo döküm verisi `kitaplar`
--

INSERT INTO `kitaplar` (`kitapin_numarasi`, `kitapin_ismi`, `kitapin_yayin_evi`, `kitapin_sayfa_sayisi`, `kitapin_turu`, `yazarin_idisi`) VALUES
(15, 'ugur hocanin hikayesi', 'guraba', 250, '', 4545),
(87, 'Birdal', 'gurabaa', 850, '', 14102),
(100, 'Angaam', 'gurabba', 584, '', 141601032),
(500, 'Ammarik', 'nidaa', 120, '', 141601032),
(520, 'Altargiiib Watarhiib', 'Nidaaa', 960, 'Islami', 123450),
(956, 'haanoom', 'gurabbaf', 4512, '', 92889426),
(4545, 'Aymak ', 'hello', 45, '', 92889426),
(8787, 'Zad Almaad', 'Gurabbaaa', 3850, 'DINI', 123450),
(8987, 'haan', 'gurabba', 4520, '', 141601032);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yazarlar`
--

CREATE TABLE IF NOT EXISTS `yazarlar` (
  `yazarin_idisi` int(32) NOT NULL AUTO_INCREMENT,
  `yazarin_ismi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `yazarin_emaili` varchar(20) COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`yazarin_idisi`),
  UNIQUE KEY `yazarin_idisi` (`yazarin_idisi`),
  UNIQUE KEY `yazarin_idisi_2` (`yazarin_idisi`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci AUTO_INCREMENT=2147483647 ;

--
-- Tablo döküm verisi `yazarlar`
--

INSERT INTO `yazarlar` (`yazarin_idisi`, `yazarin_ismi`, `yazarin_emaili`) VALUES
(1502, 'SALAHO', 'salah.com'),
(4545, 'Ugur', 'ugur.com'),
(123450, 'IBnu alkayyim', 'cfsfvsd'),
(92889426, 'Yavuzhan Aymak', 'yavuzhanaymakgmai.co'),
(141601032, 'Ammar SAEED', 'ammarçcom'),
(2147483647, 'Ammar Alyasry', 'ammar.ahmet@gmail.co');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
