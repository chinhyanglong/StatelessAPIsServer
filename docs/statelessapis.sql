-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 28, 2020 at 05:01 PM
-- Server version: 10.4.13-MariaDB
-- PHP Version: 7.4.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `statelessapis`
--

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `Id` int(11) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `Name` varchar(500) NOT NULL,
  `Description` text NOT NULL,
  `Level` enum('Basic','Advanced','Depth','') NOT NULL,
  `BeginDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `RegisterDate` datetime NOT NULL,
  `MaxPeople` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`Id`, `Code`, `Name`, `Description`, `Level`, `BeginDate`, `EndDate`, `RegisterDate`, `MaxPeople`) VALUES
(1, 'COU01', 'Angular Tutorial', 'Angular Tutorial Angular Tutorial Angular Tutorial', 'Basic', '2020-08-08 22:29:56', '2020-10-08 22:29:56', '2020-08-06 22:29:56', 20),
(2, 'COU02', 'React JS Tutorial', 'React JS Tutorial React JS Tutorial React JS Tutorial', 'Advanced', '2020-04-08 22:29:56', '2020-06-27 22:29:56', '2020-03-31 22:29:56', 15),
(3, 'COU03', 'NodeJS Tutorial', 'NodeJS Tutorial NodeJS Tutorial NodeJS Tutorial', 'Basic', '2020-07-08 22:29:56', '2020-09-08 22:29:56', '2020-07-06 22:29:56', 20),
(4, 'COU04', 'Android Tutorial', 'Android JS Tutorial Android JS Tutorial Android JS Tutorial', 'Depth', '2020-06-08 22:29:56', '2020-07-27 22:29:56', '2020-06-07 22:29:56', 15),
(5, 'COU05', 'ASPCORE', 'ASPCORE Tutorial ASPCORE Tutorial ASPCORE Tutorial', 'Advanced', '2020-07-28 14:32:38', '2020-10-28 14:32:38', '2020-07-27 14:32:38', 20);

-- --------------------------------------------------------

--
-- Table structure for table `coursestudent`
--

CREATE TABLE `coursestudent` (
  `StudentId` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `coursestudent`
--

INSERT INTO `coursestudent` (`StudentId`, `CourseId`) VALUES
(4, 1),
(5, 2),
(6, 3);

-- --------------------------------------------------------

--
-- Table structure for table `courseteacher`
--

CREATE TABLE `courseteacher` (
  `CourseId` int(11) NOT NULL,
  `TeacherId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `courseteacher`
--

INSERT INTO `courseteacher` (`CourseId`, `TeacherId`) VALUES
(1, 2),
(2, 1),
(3, 4),
(4, 3);

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `Id` int(11) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `Gender` tinyint(1) NOT NULL,
  `DayOfBirth` datetime NOT NULL,
  `Address` text DEFAULT NULL,
  `EntryPoint` float NOT NULL,
  `Name` varchar(200) NOT NULL,
  `UserName` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`Id`, `Code`, `Gender`, `DayOfBirth`, `Address`, `EntryPoint`, `Name`, `UserName`) VALUES
(4, 'HS01', 1, '1990-03-12 19:45:07', 'Hochiminh City', 7.8, 'Nguyễn Văn Minh', 'nguyenminh'),
(5, 'HS02', 0, '1992-06-04 15:05:07', 'Hanoi', 6.9, 'Phạm Phương Mai', 'phamphuong'),
(6, 'HS03', 1, '1996-06-28 12:38:12', 'bình phước', 8.4, 'Nguyễn Minh Long', 'minhlong');

-- --------------------------------------------------------

--
-- Table structure for table `studentadviser`
--

CREATE TABLE `studentadviser` (
  `StudentId` int(11) NOT NULL,
  `TeacherAdviserId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentadviser`
--

INSERT INTO `studentadviser` (`StudentId`, `TeacherAdviserId`) VALUES
(6, 1);

-- --------------------------------------------------------

--
-- Table structure for table `teacher`
--

CREATE TABLE `teacher` (
  `Id` int(11) NOT NULL,
  `Code` varchar(200) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Gender` tinyint(1) NOT NULL,
  `DayOfBirth` datetime NOT NULL,
  `ImageURL` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `teacher`
--

INSERT INTO `teacher` (`Id`, `Code`, `Name`, `Gender`, `DayOfBirth`, `ImageURL`) VALUES
(1, 'GV01', 'Phạm Bảo Khoa', 1, '1980-05-09 19:45:07', 'some/path/anImage.png'),
(2, 'GV02', 'Thu Mỵ', 0, '1987-09-16 22:27:03', 'upload/scratches_PNG6175.png'),
(3, 'GV03', 'Ngô Minh Tâm', 1, '1994-06-10 22:43:46', 'upload/scratches_PNG6175.png'),
(4, 'GV04', 'Trần Minh Như', 0, '1992-02-18 22:43:46', 'upload/scratches_PNG6335.png'),
(5, 'GV05', 'Tiến Minh', 1, '1981-06-28 14:28:23', 'upload/minh_PNG6335.png');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `UserName` varchar(200) NOT NULL,
  `Password` varchar(200) NOT NULL,
  `UserType` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`UserName`, `Password`, `UserType`) VALUES
('admin', '1234', 'Admin'),
('minhlong', '1234', 'User'),
('nguyenminh', '1234', 'User'),
('phamphuong', '1234', 'User');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200626140140_InitialCreate', '3.1.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `coursestudent`
--
ALTER TABLE `coursestudent`
  ADD PRIMARY KEY (`CourseId`);

--
-- Indexes for table `courseteacher`
--
ALTER TABLE `courseteacher`
  ADD PRIMARY KEY (`CourseId`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `studentadviser`
--
ALTER TABLE `studentadviser`
  ADD PRIMARY KEY (`StudentId`);

--
-- Indexes for table `teacher`
--
ALTER TABLE `teacher`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserName`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `teacher`
--
ALTER TABLE `teacher`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
