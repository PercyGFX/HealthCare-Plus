-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 14, 2023 at 08:14 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `healthcare`
--

-- --------------------------------------------------------

--
-- Table structure for table `appoiment`
--

CREATE TABLE `appoiment` (
  `id` int(11) NOT NULL,
  `doctor_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `description` varchar(500) NOT NULL,
  `date` date NOT NULL,
  `time` time DEFAULT NULL,
  `isactive` varchar(11) NOT NULL,
  `cost` int(100) NOT NULL,
  `InvoiceStatus` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appoiment`
--

INSERT INTO `appoiment` (`id`, `doctor_id`, `patient_id`, `description`, `date`, `time`, `isactive`, `cost`, `InvoiceStatus`) VALUES
(3, 2, 1, 'test', '2023-08-30', NULL, 'Active', 2000, 1),
(5, 2, 1, 'gffg', '2023-08-30', '00:00:00', 'Active', 200, 1),
(6, 2, 1, 'jjjjjjjjjjjjjjjjj', '2023-09-08', '00:00:00', 'Active', 989898, 1),
(7, 0, 0, 'test', '2023-10-05', '04:00:00', '1', 2000, 0),
(8, 0, 0, 'sugar check', '2023-09-07', '07:00:00', '1', 300, 0);

-- --------------------------------------------------------

--
-- Table structure for table `bill`
--

CREATE TABLE `bill` (
  `id` int(11) NOT NULL,
  `patient` int(11) NOT NULL,
  `date` date NOT NULL,
  `description` longtext NOT NULL,
  `amount` int(11) NOT NULL,
  `payment_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bill`
--

INSERT INTO `bill` (`id`, `patient`, `date`, `description`, `amount`, `payment_status`) VALUES
(4, 1, '2023-08-30', '', 3700, 1),
(5, 1, '2023-09-02', 'User ID is 1 & created on 2023/09/02', 767, 1);

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `age` int(11) NOT NULL,
  `specialized_area` varchar(100) NOT NULL,
  `location` varchar(100) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `qualifications` longtext NOT NULL,
  `is_available` int(11) NOT NULL,
  `is_active` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`id`, `name`, `age`, `specialized_area`, `location`, `phone`, `email`, `qualifications`, `is_available`, `is_active`) VALUES
(1, 'nimal ranathunga', 40, 'Heart Diseases', 'walasmulla', '0775001170', 'nimal@gmaiil.com', 'MBBS Ruhuna', 0, 0),
(2, 'Jagath ranasinghe', 10, 'nigga techjhg', 'colobo', '0774005560', 'isurangabtk@nmail.com', 'btek', 0, 0),
(3, 'Prabath', 10, 'test', 'matara', '9885006670', 'nishan@gmail.com', 'MBBS', 0, 0),
(14, 'simon', 100, 'jh', 'colombo', 'jh', 'jh', 'jh', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `meications`
--

CREATE TABLE `meications` (
  `id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `medication` varchar(100) NOT NULL,
  `description` longtext NOT NULL,
  `date` date NOT NULL,
  `cost` int(11) NOT NULL,
  `InvoiceStatus` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `meications`
--

INSERT INTO `meications` (`id`, `patient_id`, `medication`, `description`, `date`, `cost`, `InvoiceStatus`) VALUES
(1, 1, '0', '0', '2023-08-29', 300, 1),
(2, 1, 'test 2`', 'test', '2023-08-30', 400, 1);

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `age` int(11) NOT NULL,
  `blood_type` varchar(50) NOT NULL,
  `description` longtext NOT NULL,
  `is_active` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`id`, `name`, `address`, `phone`, `age`, `blood_type`, `description`, `is_active`) VALUES
(1, 'Sumanapaala', '123/asds k', '0775004460', 30, 'A+', 'sugar issue, skill issue', 'Active'),
(2, 'Nimal', 'waduraba', '0775006670', 45, 'A+', 'Skill Issue', 'Active'),
(3, 'Sugathapaala', 'Kirama', '75500660', 30, 'a+', 'issues with tissues', 'Active'),
(4, 'sugatha', 'derana', '0775001170', 30, 'b-', 'skill issue with', 'Active'),
(5, 'nimal', '123', '8987', 20, 'b-', 'kamal', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `patient_records`
--

CREATE TABLE `patient_records` (
  `id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `record_name` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `record_type` varchar(400) NOT NULL,
  `record` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patient_records`
--

INSERT INTO `patient_records` (`id`, `patient_id`, `record_name`, `date`, `record_type`, `record`) VALUES
(1, 1, 'test', '2023-08-31', 'Diagnose', 'Test test');

-- --------------------------------------------------------

--
-- Table structure for table `resources`
--

CREATE TABLE `resources` (
  `id` int(11) NOT NULL,
  `name` varchar(500) NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `resources`
--

INSERT INTO `resources` (`id`, `name`, `description`) VALUES
(1, 'record 1', 'test'),
(2, 'Test 2', 'Test 2');

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `id` int(11) NOT NULL,
  `room_name` varchar(50) NOT NULL,
  `room_type` varchar(50) NOT NULL,
  `availability` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`id`, `room_name`, `room_type`, `availability`) VALUES
(1, 'Room 1', 'Normal', 1),
(2, 'Room 2', 'Normal', 0),
(3, 'Room 3', 'Normal', 1);

-- --------------------------------------------------------

--
-- Table structure for table `room_allowcation`
--

CREATE TABLE `room_allowcation` (
  `id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `room_id` int(11) NOT NULL,
  `admit_date` date NOT NULL,
  `discharge_date` date DEFAULT NULL,
  `cost` int(11) NOT NULL,
  `InvoiceStatus` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `room_allowcation`
--

INSERT INTO `room_allowcation` (`id`, `patient_id`, `room_id`, `admit_date`, `discharge_date`, `cost`, `InvoiceStatus`) VALUES
(1, 1, 1, '2023-08-30', '2023-08-31', 200, 1),
(2, 1, 2, '2023-08-30', NULL, 300, 1);

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `phone` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`id`, `user_id`, `name`, `address`, `phone`) VALUES
(1, 2, 'hgf', 'hgf', '0775001170'),
(2, 3, 'hgf', 'hgf', '0775001170');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `email`, `username`, `password`, `role`) VALUES
(1, 'isurangabtk@gmail.com', 'admin', '25d55ad283aa400af464c76d713c07ad', 1),
(2, 'hgf', 'yuggh', 'ff3d025d04b0dafd333a401f2ce2341f', 2),
(3, 'hgf', 'user', '25d55ad283aa400af464c76d713c07ad', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appoiment`
--
ALTER TABLE `appoiment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `meications`
--
ALTER TABLE `meications`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patient_records`
--
ALTER TABLE `patient_records`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `resources`
--
ALTER TABLE `resources`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room_allowcation`
--
ALTER TABLE `room_allowcation`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appoiment`
--
ALTER TABLE `appoiment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `bill`
--
ALTER TABLE `bill`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `doctor`
--
ALTER TABLE `doctor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `meications`
--
ALTER TABLE `meications`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `patient_records`
--
ALTER TABLE `patient_records`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `resources`
--
ALTER TABLE `resources`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `room_allowcation`
--
ALTER TABLE `room_allowcation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `staff`
--
ALTER TABLE `staff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
