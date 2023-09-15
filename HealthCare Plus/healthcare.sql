-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 15, 2023 at 08:21 PM
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
(10, 16, 8, 'Normal appoinment', '2023-09-22', '06:00:00', 'Active', 2500, 1);

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
(6, 8, '2023-09-15', 'User ID is 8 & created on 2023/09/15', 2500, 1),
(7, 7, '2023-09-15', 'Patient ID is 7 & created on 2023/09/15', 3500, 0);

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
(16, 'Dr. Kamal Gunawardene', 35, 'Heart', 'Matara', '076300560', 'kamal.guna@gmail.com', 'MBBS', 0, 0),
(17, 'Dr. Nimal Rathnayake', 42, 'Neurology', 'Colombo', '071234567', 'nimalrathnayake@gmail.com', 'MD', 0, 0),
(18, 'Dr. Liyanage Bandara', 43, 'Ophthalmology', 'Badulla', '079876543', 'liyanagebandara@gmail.com', 'MD', 0, 0),
(19, 'Dr. Kirshantha', 36, 'Pulmonology', 'Anuradhapura', '074321098', 'krishantha@gmail.com', 'MBBS, MD', 0, 0);

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
(3, 7, 'For Sugar', '500mg insulin', '2023-09-22', 500, 1);

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
(7, 'Nimal Silva', '123/a Matara', '077334450', 34, 'A+', 'blood sugar', 'Active'),
(8, 'Mrs Pavani', '456/A Colombo', '071234567', 45, 'B-', 'Ko known issues', 'Active'),
(9, 'Kamal Gunasena', '789/c Galle', '076543210', 28, 'O+', 'asthma', 'Active'),
(10, 'Bandara perera', '333/f Nuwara', '078765432', 41, 'O+', 'heart condition', 'Active');

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
(2, 8, 'High Suger', '2023-09-22', 'Diagnose', 'High Sugar');

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
(4, 'X- Ray Machine', 'Nestled within the bustling corridors of our hospital, the MarvelScan X-ray machine is an indispensable tool in our mission to provide top-tier healthcare.');

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
(7, 'Room 1', 'Normal', 1),
(8, 'Room 2', 'Normal', 1),
(9, 'North Room', 'VIP', 1),
(10, 'LifeCare Theater', 'Normal', 1),
(11, 'Room 3', 'Normal', 1);

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
(3, 7, 7, '2023-09-23', '2023-09-27', 750, 1);

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
(9, 10, 'Nishantha', 'Matara', '0775001170');

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
(10, 'nishantha@gmail.com', 'user', '25d55ad283aa400af464c76d713c07ad', 2);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `bill`
--
ALTER TABLE `bill`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `doctor`
--
ALTER TABLE `doctor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `meications`
--
ALTER TABLE `meications`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `patient_records`
--
ALTER TABLE `patient_records`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `resources`
--
ALTER TABLE `resources`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `room_allowcation`
--
ALTER TABLE `room_allowcation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `staff`
--
ALTER TABLE `staff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
