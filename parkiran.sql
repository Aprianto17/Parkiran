-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 28, 2018 at 03:13 AM
-- Server version: 10.1.28-MariaDB
-- PHP Version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `parkiran`
--

-- --------------------------------------------------------

--
-- Table structure for table `daftar_nota`
--

CREATE TABLE `daftar_nota` (
  `Kode` char(8) NOT NULL,
  `No_Plat` varchar(10) NOT NULL,
  `Jenis_Kendaraan` varchar(25) NOT NULL,
  `Waktu` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `daftar_nota`
--

INSERT INTO `daftar_nota` (`Kode`, `No_Plat`, `Jenis_Kendaraan`, `Waktu`) VALUES
('00000010', 'DD 1235 TT', 'Mobil', '2018-11-13 12:08:00'),
('00000011', 'DD 9061 YT', 'Motor', '2018-11-13 19:50:00'),
('00000012', 'DD 3416 GG', 'Motor', '2018-11-13 19:56:00'),
('00000013', 'DD 567 QR', 'Motor', '2018-11-14 12:26:00'),
('00000016', 'DD 5674 TY', 'Mobil', '2018-11-21 11:09:00');

-- --------------------------------------------------------

--
-- Table structure for table `parkir_keluar`
--

CREATE TABLE `parkir_keluar` (
  `Kode` int(11) NOT NULL,
  `Kode_Nota` char(8) NOT NULL,
  `No_Plat` varchar(10) NOT NULL,
  `Jenis_Kendaraan` varchar(25) NOT NULL,
  `Waktu_Masuk` datetime DEFAULT NULL,
  `Waktu_Keluar` datetime DEFAULT NULL,
  `Jumlah_Bayar` int(11) DEFAULT NULL,
  `Bayar` int(11) DEFAULT NULL,
  `Kembali` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `parkir_keluar`
--

INSERT INTO `parkir_keluar` (`Kode`, `Kode_Nota`, `No_Plat`, `Jenis_Kendaraan`, `Waktu_Masuk`, `Waktu_Keluar`, `Jumlah_Bayar`, `Bayar`, `Kembali`) VALUES
(1, '00000001', 'DD 1234 QQ', 'Mobil', '2018-06-30 17:33:00', '2018-06-30 17:34:00', 3000, 5000, 2000),
(2, '00000004', 'DD 1904 OP', 'Motor', '2018-07-09 13:30:00', '2018-07-09 13:30:00', 2000, 100000, 98000),
(3, '00000005', 'DD 12345', 'Motor', '2018-07-13 10:17:00', '2018-07-13 10:18:00', 2000, 5000, 3000),
(4, '00000003', 'DD 1054 WE', 'Motor', '2018-06-30 17:34:00', '2018-07-13 10:18:00', 8000, 10000, 2000),
(5, '00000002', 'DD 6194 YT', 'Mobil', '2018-06-30 17:34:00', '2018-10-25 14:21:00', 12000, 15000, 3000),
(6, '00000007', 'DD 1234 YY', 'Motor', '2018-10-31 18:27:00', '2018-11-07 18:05:00', 5000, 10000, 5000),
(7, '00000006', 'DD 12356 Y', 'Mobil', '2018-07-19 14:35:00', '2018-11-13 19:55:00', 10000, 10000, 0),
(8, '00000008', 'DD 2967', 'Motor', '2018-11-07 17:44:00', '2018-11-14 12:24:00', 5000, 10000, 5000),
(9, '00000009', 'DD 1450 EE', 'Mobil', '2018-11-13 11:57:00', '2018-11-14 12:25:00', 10000, 15000, 5000),
(10, '00000015', 'DD 3456 TH', 'Mobil', '2018-11-21 11:03:00', '2018-11-21 11:04:00', 4000, 5000, 1000),
(11, '00000014', 'DD 34567 Y', 'Mobil', '2018-11-21 10:54:00', '2018-11-21 11:05:00', 4000, 4000, 0),
(12, '00000017', 'dd 1764 a', 'Mobil', '2018-11-22 17:00:00', '2018-11-22 17:01:00', 4000, 5000, 1000);

-- --------------------------------------------------------

--
-- Table structure for table `parkir_masuk`
--

CREATE TABLE `parkir_masuk` (
  `Kode` char(8) NOT NULL,
  `No_Plat` varchar(10) NOT NULL,
  `Jenis_Kendaraan` varchar(25) NOT NULL,
  `Waktu` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `parkir_masuk`
--

INSERT INTO `parkir_masuk` (`Kode`, `No_Plat`, `Jenis_Kendaraan`, `Waktu`) VALUES
('00000001', 'DD 1234 QQ', 'Mobil', '2018-06-30 17:33:00'),
('00000002', 'DD 6194 YT', 'Mobil', '2018-06-30 17:34:00'),
('00000003', 'DD 1054 WE', 'Motor', '2018-06-30 17:34:00'),
('00000004', 'DD 1904 OP', 'Motor', '2018-07-09 13:30:00'),
('00000005', 'DD 12345', 'Motor', '2018-07-13 10:17:00'),
('00000006', 'DD 12356 Y', 'Mobil', '2018-07-19 14:35:00'),
('00000007', 'DD 1234 YY', 'Motor', '2018-10-31 18:27:00'),
('00000008', 'DD 2967', 'Motor', '2018-11-07 17:44:00'),
('00000009', 'DD 1450 EE', 'Mobil', '2018-11-13 11:57:00'),
('00000010', 'DD 1235 TT', 'Mobil', '2018-11-13 12:08:00'),
('00000011', 'DD 9061 YT', 'Motor', '2018-11-13 19:50:00'),
('00000012', 'DD 3416 GG', 'Motor', '2018-11-13 19:56:00'),
('00000013', 'DD 567 QR', 'Motor', '2018-11-14 12:26:00'),
('00000014', 'DD 34567 Y', 'Mobil', '2018-11-21 10:54:00'),
('00000015', 'DD 3456 TH', 'Mobil', '2018-11-21 11:03:00'),
('00000016', 'DD 5674 TY', 'Mobil', '2018-11-21 11:09:00'),
('00000017', 'dd 1764 a', 'Mobil', '2018-11-22 17:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tarif_parkir`
--

CREATE TABLE `tarif_parkir` (
  `jenis` varchar(5) DEFAULT NULL,
  `jam_pertama` int(11) DEFAULT NULL,
  `jam_brikut` int(11) DEFAULT NULL,
  `max` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tarif_parkir`
--

INSERT INTO `tarif_parkir` (`jenis`, `jam_pertama`, `jam_brikut`, `max`) VALUES
('Mobil', 4000, 2000, 15000),
('Motor', 2000, 1000, 5000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `daftar_nota`
--
ALTER TABLE `daftar_nota`
  ADD PRIMARY KEY (`Kode`);

--
-- Indexes for table `parkir_keluar`
--
ALTER TABLE `parkir_keluar`
  ADD PRIMARY KEY (`Kode`);

--
-- Indexes for table `parkir_masuk`
--
ALTER TABLE `parkir_masuk`
  ADD PRIMARY KEY (`Kode`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `parkir_keluar`
--
ALTER TABLE `parkir_keluar`
  MODIFY `Kode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
