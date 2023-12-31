USE [zencareservice]
GO
/****** Object:  Table [dbo].[DocumentcodeTbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentcodeTbl](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[Seriesname] [nvarchar](100) NULL,
	[Keyword] [nvarchar](100) NULL,
	[CurrentNo] [int] NULL,
	[PadNo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Documentcode_vw]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Documentcode_vw]
as
select Seriesname,Keyword+RIGHT(REPLICATE('0', PadNo) + cast(CurrentNo+1 as varchar(100)), PadNo) as docno 
from DocumentcodeTbl
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AptId] [int] IDENTITY(1,1) NOT NULL,
	[AptCode] [varchar](255) NULL,
	[RCode] [varchar](255) NULL,
	[AptBookingdate] [date] NULL,
	[AptTime] [time](7) NULL,
	[Aptbookingconfirm] [int] NULL,
	[Aptbookingstatusconfirm] [int] NULL,
	[Aptcreatedate] [date] NULL,
	[Aptrescheduleconfirm] [int] NULL,
	[Aptrescheduledate] [date] NULL,
	[Aptrescheduletime] [time](7) NULL,
	[Reasontype] [varchar](255) NULL,
	[PatientEmail] [varchar](255) NULL,
	[PerCode] [varchar](255) NULL,
	[PFname] [varchar](255) NULL,
	[PLname] [varchar](255) NULL,
	[DFname] [varchar](255) NULL,
	[DLname] [varchar](255) NULL,
	[Patage] [varchar](255) NULL,
	[Patgender] [varchar](255) NULL,
	[Patphone] [varchar](255) NULL,
	[PatPhoto] [varbinary](max) NULL,
	[Pataddress1] [varchar](255) NULL,
	[Pataddress2] [varchar](255) NULL,
	[PState] [varchar](255) NULL,
	[PCity] [varchar](255) NULL,
 CONSTRAINT [AptCode] UNIQUE NONCLUSTERED 
(
	[AptCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment_tbl](
	[Id] [int] NOT NULL,
	[regno] [uniqueidentifier] NOT NULL,
	[regname] [varchar](250) NULL,
	[username] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[apptid] [nvarchar](max) NULL,
	[apptstatusno] [varchar](250) NULL,
	[prsnid] [nvarchar](max) NULL,
	[fname] [varchar](250) NULL,
	[lastname] [varchar](250) NULL,
	[patname] [varchar](250) NOT NULL,
	[patid] [nvarchar](max) NOT NULL,
	[patphone] [varchar](250) NOT NULL,
	[pataddress] [nvarchar](max) NOT NULL,
	[docname] [varchar](250) NOT NULL,
	[docid] [nvarchar](max) NOT NULL,
	[reasontype] [varchar](250) NULL,
	[apptbookingdate] [datetime] NOT NULL,
	[apptbookingtime] [varchar](250) NOT NULL,
	[apptbookingconfirm] [bit] NULL,
	[apptbookingstatusconfirm] [bit] NULL,
	[apptcreateddate] [datetime] NULL,
	[apptrescheduleconfirm] [bit] NULL,
 CONSTRAINT [PK_Appointment_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointmentstatus]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointmentstatus](
	[ASId] [int] IDENTITY(1,1) NOT NULL,
	[AptCode] [varchar](255) NULL,
	[RCode] [varchar](255) NULL,
	[AptBookingdate] [date] NULL,
	[AptBooking] [time](7) NULL,
	[Reasontype] [varchar](255) NULL,
	[Aptbookingconfirm] [int] NULL,
	[Aptbookingstatusconfirm] [int] NULL,
	[Aptreschedule] [date] NULL,
	[Aptrescheduletime] [time](7) NULL,
	[Aptrecreatedate] [datetime] NULL,
	[PFname] [varchar](255) NULL,
	[PLname] [varchar](255) NULL,
	[DFname] [varchar](255) NULL,
	[DLname] [varchar](255) NULL,
	[Patage] [varchar](25) NULL,
	[Patgender] [varchar](25) NULL,
	[PatPhone] [varchar](14) NULL,
	[PatientEmail] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointmentstatus_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointmentstatus_tbl](
	[Id] [int] NOT NULL,
	[regno] [uniqueidentifier] NULL,
	[username] [varchar](250) NULL,
	[email] [varchar](250) NULL,
	[patname] [varchar](250) NOT NULL,
	[patid] [nvarchar](max) NOT NULL,
	[patphoneno] [varchar](250) NOT NULL,
	[pataddress] [nvarchar](max) NULL,
	[docname] [varchar](250) NOT NULL,
	[docid] [varchar](250) NOT NULL,
	[apptstatusid] [nvarchar](max) NULL,
	[apptconfirmstatusno] [varchar](250) NOT NULL,
	[apptbookingconfirmdate] [datetime] NOT NULL,
	[apptbookingconfirmtime] [varchar](250) NOT NULL,
	[apptbookingstatus] [bit] NULL,
	[apptrescheduledate] [datetime] NULL,
	[apptrescheduletime] [varchar](250) NULL,
	[apptrescheduleconfirm] [bit] NULL,
 CONSTRAINT [PK_Appointmentstatus_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country_tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CId] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DId] [int] IDENTITY(1,1) NOT NULL,
	[PerCode] [varchar](255) NULL,
	[RCode] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[DFname] [varchar](255) NULL,
	[DLname] [varchar](255) NULL,
	[Dage] [varchar](3) NULL,
	[Dgender] [varchar](255) NULL,
	[DAddress] [nvarchar](max) NULL,
	[Dphone] [varchar](14) NULL,
	[ADphone] [varchar](14) NULL,
	[Practionerproof] [varbinary](max) NULL,
	[Dphoto] [varbinary](max) NULL,
	[Dexp] [varchar](12) NULL,
	[Dqualification] [varchar](255) NULL,
	[Dspecialist] [varchar](255) NULL,
	[DDob] [date] NULL,
	[UsrId] [int] NULL,
 CONSTRAINT [UQ_Doctor_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctordetails_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctordetails_tbl](
	[Id] [int] NOT NULL,
	[prsnid] [nvarchar](max) NULL,
	[regid] [uniqueidentifier] NOT NULL,
	[regname] [varchar](250) NULL,
	[email] [varchar](250) NOT NULL,
	[docid] [nvarchar](max) NOT NULL,
	[docname] [varchar](250) NOT NULL,
	[docaddress] [nvarchar](max) NOT NULL,
	[docphoneno] [varchar](250) NOT NULL,
	[docphoto] [nvarchar](max) NULL,
	[practionerid] [varchar](250) NOT NULL,
	[practionerproof] [nvarchar](max) NULL,
	[docexperience] [nvarchar](max) NOT NULL,
	[docqualification] [varchar](250) NOT NULL,
	[docspecialist] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Doctordetails_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctorspecialist_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctorspecialist_tbl](
	[Id] [int] NOT NULL,
	[sno] [int] NOT NULL,
	[specialistid] [varchar](250) NOT NULL,
	[specialistname] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Doctorspecialist_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[logindate] [datetime] NULL,
	[lastlogin] [datetime] NULL,
	[Fname] [varchar](255) NULL,
	[Lname] [varchar](255) NULL,
	[RCode] [varchar](255) NULL,
	[Dob] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modules]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modules](
	[ModuleId] [int] NOT NULL,
	[ModuleName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patdiagnosis]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patdiagnosis](
	[PDId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](max) NULL,
	[PDCode] [varchar](255) NULL,
	[PFname] [varchar](255) NULL,
	[PLname] [varchar](255) NULL,
	[Patphoneno] [varchar](14) NULL,
	[Patage] [varchar](14) NULL,
	[Patgender] [varchar](14) NULL,
	[DFname] [varchar](255) NULL,
	[DLname] [varchar](255) NULL,
	[PatSymptoms] [varchar](255) NULL,
	[Patdiagnosisdetails] [nvarchar](max) NULL,
	[Patdiagnosisproof] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patdiagnosis_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patdiagnosis_tbl](
	[Id] [int] NOT NULL,
	[regname] [varchar](250) NOT NULL,
	[regno] [uniqueidentifier] NOT NULL,
	[email] [varchar](250) NULL,
	[patdiagnosisid] [nvarchar](max) NOT NULL,
	[docname] [varchar](250) NOT NULL,
	[docid] [nvarchar](max) NULL,
	[patname] [varchar](250) NOT NULL,
	[patid] [nvarchar](max) NULL,
	[patsymptoms] [nvarchar](max) NULL,
	[patdiagnosisdetails] [nvarchar](max) NOT NULL,
	[patdiagnosisproof] [nvarchar](max) NULL,
	[patdiagnosismethod] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Patdiagnosis_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](255) NULL,
	[PCode] [varchar](255) NULL,
	[Percode] [varchar](255) NULL,
	[UsrId] [int] NULL,
	[PEmail] [varchar](255) NULL,
	[PFname] [varchar](255) NULL,
	[PLname] [varchar](255) NULL,
	[PDob] [datetime] NULL,
	[Patage] [varchar](25) NULL,
	[Patgender] [varchar](25) NULL,
	[Pataddress1] [nvarchar](max) NULL,
	[Pataddress2] [nvarchar](max) NULL,
	[Patphoneno] [varchar](255) NULL,
	[Pataltphone] [varchar](255) NULL,
	[PCity] [varchar](255) NULL,
	[Puniqueid] [varchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patientdetails]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patientdetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PId] [int] NULL,
	[RCode] [varchar](255) NULL,
	[Rname] [varchar](255) NULL,
	[Patname] [varchar](255) NULL,
	[Patage] [int] NULL,
	[Patgender] [varchar](255) NULL,
	[Pataddress1] [varchar](255) NULL,
	[Pataddress2] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Pincode] [varchar](255) NULL,
	[Attendeephoneno] [varchar](255) NULL,
	[Patphoto] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patientdetails_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patientdetails_tbl](
	[Id] [int] NOT NULL,
	[prsnid] [nvarchar](max) NULL,
	[regid] [uniqueidentifier] NOT NULL,
	[regname] [varchar](250) NULL,
	[email] [varchar](250) NOT NULL,
	[patid] [nvarchar](max) NOT NULL,
	[patname] [varchar](250) NOT NULL,
	[pataddress] [nvarchar](max) NOT NULL,
	[patage] [int] NOT NULL,
	[patgender] [varchar](50) NULL,
	[patphoneno] [varchar](250) NOT NULL,
	[attendeephoneno] [varchar](250) NOT NULL,
	[patphoto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Patientdetails_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patientdisease_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patientdisease_tbl](
	[Id] [int] NOT NULL,
	[regname] [varchar](250) NOT NULL,
	[regno] [uniqueidentifier] NOT NULL,
	[email] [varchar](250) NULL,
	[patdiseaseid] [nvarchar](max) NOT NULL,
	[patdisease] [varchar](250) NOT NULL,
	[patname] [varchar](250) NOT NULL,
	[patid] [varchar](250) NOT NULL,
	[patphoneno] [varchar](250) NOT NULL,
	[patdiseasedetails] [nvarchar](max) NOT NULL,
	[patsymptoms] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Patientdisease_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionId] [int] NOT NULL,
	[PermissionName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personaldetails]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personaldetails](
	[PerId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](255) NULL,
	[PerCode] [nvarchar](100) NULL,
	[Fname] [varchar](100) NULL,
	[Lname] [varchar](100) NULL,
	[Age] [varchar](3) NULL,
	[Gender] [varchar](100) NULL,
	[Email] [varchar](255) NULL,
	[Phoneno] [varchar](14) NULL,
	[Aphoneno] [varchar](14) NULL,
	[UniqueId] [varchar](255) NULL,
	[Addressline] [nvarchar](max) NULL,
	[Addressline2] [nvarchar](max) NULL,
	[AltAddress] [nvarchar](max) NULL,
	[State] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[Photo] [varbinary](max) NULL,
	[UsrId] [int] NULL,
	[Dob] [datetime] NULL,
	[Role] [varchar](255) NULL,
 CONSTRAINT [UQ_Personaldetails_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personaldetails_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personaldetails_tbl](
	[Id] [int] NOT NULL,
	[prsnid] [nvarchar](max) NOT NULL,
	[fname] [varchar](250) NOT NULL,
	[lastname] [varchar](250) NOT NULL,
	[dob] [datetime] NOT NULL,
	[age] [int] NOT NULL,
	[gender] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[phoneno] [varchar](250) NOT NULL,
	[altphoneno] [varchar](250) NOT NULL,
	[uniqueid] [varchar](250) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[altaddress] [nvarchar](max) NOT NULL,
	[state] [varchar](250) NOT NULL,
	[city] [varchar](250) NOT NULL,
	[country] [varchar](50) NULL,
	[photo] [nvarchar](max) NULL,
	[phonenoverified] [bit] NULL,
 CONSTRAINT [PK_Personaldetails_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[PrsId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](255) NULL,
	[PrsCode] [varchar](255) NULL,
	[PDCode] [varchar](255) NULL,
	[TCode] [varchar](255) NULL,
	[PFname] [varchar](255) NULL,
	[PLname] [varchar](255) NULL,
	[DFname] [varchar](255) NULL,
	[DLname] [varchar](255) NULL,
	[Patphoneno] [varchar](14) NULL,
	[Patage] [varchar](14) NULL,
	[Patgender] [varchar](14) NULL,
	[Prescdetails] [nvarchar](max) NULL,
	[Prescproof] [varbinary](max) NULL,
	[PatTreatmentdetails] [nvarchar](max) NULL,
	[PatTreatmentproof] [varbinary](max) NULL,
	[Patdiagnosisdetails] [nvarchar](max) NULL,
	[Patdiagnosisproof] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescriptiondetails_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescriptiondetails_tbl](
	[Id] [int] NOT NULL,
	[prsnid] [nvarchar](max) NOT NULL,
	[regid] [uniqueidentifier] NULL,
	[regname] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[prescid] [nvarchar](max) NOT NULL,
	[docname] [varchar](250) NOT NULL,
	[docid] [nvarchar](max) NULL,
	[patientname] [varchar](250) NOT NULL,
	[patientid] [nvarchar](max) NULL,
	[patphoneno] [varchar](250) NULL,
	[patdisease] [nvarchar](max) NOT NULL,
	[diagnosisdetails] [nvarchar](max) NULL,
	[treatmentdetails] [nvarchar](max) NOT NULL,
	[treatmentid] [nvarchar](max) NOT NULL,
	[prescdetails] [nvarchar](max) NOT NULL,
	[prescproof] [nvarchar](max) NULL,
	[prescdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Prescriptiondetails_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[RId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](255) NULL,
	[Fname] [varchar](255) NULL,
	[Lname] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[CPassword] [varchar](255) NULL,
	[Username] [varchar](255) NULL,
	[Dob] [datetime] NULL,
	[Status] [int] NULL,
	[Role] [varchar](255) NULL,
	[Phoneno] [varchar](16) NULL,
	[Regdate] [datetime] NULL,
	[agreeterm] [int] NULL,
 CONSTRAINT [unique_emailid] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleModuleMapping]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModuleMapping](
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NULL,
	[PermissionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissionMapping]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissionMapping](
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NULL,
	[PermissionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[SId] [int] IDENTITY(1,1) NOT NULL,
	[PerCode] [varchar](255) NULL,
	[RCode] [varchar](255) NULL,
	[UsrId] [int] NULL,
	[SEmail] [varchar](255) NULL,
	[SFname] [varchar](255) NULL,
	[SLname] [varchar](255) NULL,
	[Sage] [varchar](22) NULL,
	[Sgender] [varchar](22) NULL,
	[SAddress] [varchar](255) NULL,
	[SPhone] [varchar](14) NULL,
	[SDob] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State_tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SId] [varchar](255) NULL,
	[State] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatment]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatment](
	[TId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](255) NULL,
	[PDCode] [varchar](255) NULL,
	[TCode] [varchar](max) NULL,
	[PFname] [varchar](255) NULL,
	[PLname] [varchar](255) NULL,
	[DFname] [varchar](255) NULL,
	[DLname] [varchar](255) NULL,
	[Patage] [varchar](14) NULL,
	[Patgender] [varchar](14) NULL,
	[Patphoneno] [varchar](14) NULL,
	[PatSymptoms] [varchar](255) NULL,
	[PatTreatmentdetails] [nvarchar](max) NULL,
	[PatTreatmentproof] [varbinary](max) NULL,
	[Patdiagnosisdetails] [nvarchar](max) NULL,
	[Patdiagnosisproof] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatment_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatment_tbl](
	[Id] [int] NOT NULL,
	[regname] [varchar](250) NOT NULL,
	[regno] [uniqueidentifier] NULL,
	[email] [varchar](250) NULL,
	[pattreatmentid] [nvarchar](max) NOT NULL,
	[patdiseasedetials] [nvarchar](max) NOT NULL,
	[patdiseaseid] [nvarchar](max) NOT NULL,
	[patname] [varchar](250) NOT NULL,
	[patid] [nvarchar](max) NULL,
	[docname] [varchar](250) NOT NULL,
	[docid] [nvarchar](max) NULL,
	[patdiagnosisid] [nvarchar](max) NULL,
	[patdiagnosisdetails] [nvarchar](max) NOT NULL,
	[patdiagnosisproof] [nvarchar](max) NULL,
	[pattreatmentdetails] [nvarchar](max) NOT NULL,
	[pattreatmentproof] [nvarchar](max) NULL,
	[pattreatmentmethod] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Treatment_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userrole_tbl]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userrole_tbl](
	[Id] [int] NOT NULL,
	[userroleid] [nvarchar](max) NOT NULL,
	[userrolename] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Userrole_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NULL,
	[Username] [varchar](255) NULL,
	[RoleId] [int] NULL,
	[Rolename] [varchar](255) NULL,
	[Password] [varchar](255) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoleModuleMapping]  WITH CHECK ADD FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Modules] ([ModuleId])
GO
ALTER TABLE [dbo].[RoleModuleMapping]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([PermissionId])
GO
ALTER TABLE [dbo].[RoleModuleMapping]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[RolePermissionMapping]  WITH CHECK ADD FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Modules] ([ModuleId])
GO
ALTER TABLE [dbo].[RolePermissionMapping]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([PermissionId])
GO
ALTER TABLE [dbo].[RolePermissionMapping]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
/****** Object:  StoredProcedure [dbo].[AppointmentBooking_SP]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AppointmentBooking_SP] @PatientFirstname nvarchar(255),@PatientLastname varchar(255),@PatientEmail varchar(255),@DoctorFirstname varchar(255),@DoctorLastname varchar(255),                          
@AptBookdate date,@AptTime time,@ReasonType  varchar(255),                       
@Patgender varchar(255),@Patientage varchar(255),@PatientAddress1 varchar(255),@PatientAddress2 varchar(255),@PState varchar(255),@PCity varchar(255),@PatientPhoneno varchar(14)          
                        
as                              
begin                           
declare  @AptCode nvarchar(100)               
declare @count int                          
declare @tblid Table(AptId int)              
                          
  
      
insert into Appointment(Reasontype,PatientEmail,PFname,PLname,Patgender,DFname,DLname,AptBookingdate,AptTime,Aptcreatedate,Pataddress1,Pataddress2,Pstate,PCity,Patphone,Patage)                           
Output inserted.AptId into @tblid                                      
values(@ReasonType,@PatientEmail,@PatientFirstname,@PatientLastname,@Patgender,@DoctorFirstname,@DoctorLastname,@AptBookdate,@Apttime,getdate(),@PatientAddress1,@PatientAddress2,@PState,@PCity,@Patientphoneno,@Patientage)                             
select @AptCode='APT-100'+cast(AptId as varchar(100)) from Appointment where AptId in (select AptId from @tblid)  
Update Appointment set AptCode=@AptCode where AptId in (select AptId from @tblid)                   
    
end
GO
/****** Object:  StoredProcedure [dbo].[AuthenticateUser]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthenticateUser]
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SELECT UserId, Username, RoleId, Rolename
    FROM Users
    WHERE Username = @Username AND Password = @Password;
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckLogin_SP]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CheckLogin_SP] @Uname nvarchar(100),@Pass nvarchar(100) as  
begin          
declare @count int          
declare @LL datetime          
select @count=count(*) from Register where Username=@Uname or Email=@Uname and Password=@Pass     
if @count>0          
begin          
select @LL=Logindate from login where lid in  (select max(LId) from login where  Username=@Uname and Password=@Pass)          
insert into login(Fname,Lname,Username, Password,Email,logindate,lastlogin,RCode)            
select Fname,Lname, Username,Password,Email,getdate(),@LL,RCode from Register where Username=@Uname or Email=@Uname and Password=@Pass         
      
select RId,RCode,Fname,Lname,Email,Password,CPassword,Username,Dob,Phoneno,Status,Role,1 as LStatus from Register      
where Username=@Uname  or Email=@Uname and Password=@Pass       
      
      
end        
else      
select 0 as LStatus      
      
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmaildetails]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmaildetails] @Email varchar(255)
  
AS  
  
BEGIN  
  
      SET NOCOUNT ON;  
  
      SELECT * from Register where Email =@Email
  
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPersonalDetails]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPersonalDetails] @UsrId int

AS

BEGIN

      SET NOCOUNT ON;

      SELECT PerId, RCode, PerCode, Fname, Lname,Dob,Email, Phoneno 

      FROM Personaldetails where UsrId=@UsrId

END
GO
/****** Object:  StoredProcedure [dbo].[GetModulesByRole]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetModulesByRole]
    @RoleId INT
AS
BEGIN
    SELECT Modules.ModuleId, ModuleName
    FROM Modules
    JOIN RoleModuleMapping ON Modules.ModuleId = RoleModuleMapping.ModuleId
    WHERE RoleModuleMapping.RoleId = @RoleId;
END;
GO
/****** Object:  StoredProcedure [dbo].[Prescription_SP]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prescription_SP] @PatientFirstname nvarchar(255),@PatientLastname varchar(255),@DoctorFirstname varchar(255),@DoctorLastname varchar(255),                                                  
@Patgender varchar(255),@Patientage varchar(255),@PatientPhoneno varchar(25)
as                                
begin                             
declare  @PrsCode nvarchar(100)                 
declare @count int                            
declare @tblid Table(PrsId int)                
                              
insert into Prescription(PFname,PLname,DFname,DLname,Patphoneno,Patage,Patgender)                             
Output inserted.PrsId into @tblid                                        
values(@PatientFirstname,@PatientLastname,@DoctorFirstname,@DoctorLastname,@Patientphoneno,@Patientage,@Patgender)                               
select @PrsCode='PRSC-100'+cast(PrsId as varchar(100)) from Prescription where PrsId in (select PrsId from @tblid)    
Update Prescription set PrsCode=@PrsCode where PrsId in (select PrsId from @tblid)                     
      
end
GO
/****** Object:  StoredProcedure [dbo].[SaveRegister_SP]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SaveRegister_SP] @Firstname nvarchar(255),@Lastname varchar(255),@Email varchar(255),                        
@Password varchar(255),@ConfirmPassword varchar(255),@Username varchar(255),@Dob datetime,@Phone varchar(255),@Status int,                        
@Role varchar(255),@agreeterm int                                  
as                            
begin                         
declare  @RCode nvarchar(100)         
declare @PerCode nvarchar(100)       
declare @count int                        
declare @tblid Table(RId int)       
declare @Pertblid Table (PerId int)      
declare @Ptblid Table(PId int)          
declare @Dtblid Table(DId int)          

if @Role='Patient' 
--select @PerCode='PR-100'+cast(RId as varchar(100)) from Register where RId in (select RId from @tblid)
select @RCode=Docno from Documentcode_vw where Seriesname='Patient'

if @Role='Doctor'
select @RCode=Docno from Documentcode_vw where Seriesname='Doctor'

if @Role='Staff'
select @RCode=Docno from Documentcode_vw where Seriesname='Staff'


insert into Register(Fname,Lname,Email,Password,CPassword,Username,Dob,Phoneno,Role,Status,Regdate,agreeterm,RCode)                         
Output inserted.RId into @tblid                                    
values(@Firstname,@Lastname,@Email,@Password,@ConfirmPassword,@Username,@Dob,@Phone,@Role,@Status,getdate(),@agreeterm,@RCode)  



select @PerCode=Docno from Documentcode_vw where Seriesname='Personaldetail'

declare @UId int      
select @UId=rid from @tblid   
insert into Personaldetails(Fname,Lname,Email,Phoneno,Dob,UsrId,Role,PerCode,RCode)        
Output inserted.PerId into @Pertblid      
values(@Firstname,@Lastname,@Email,@Phone,@Dob,@UId,@Role,@PerCode,@RCode)  
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Personaldetail'

if @Role='Patient'
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Patient'

if @Role='Doctor'
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Doctor'

if @Role='Staff'
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Staff'
         
----if @Role='Patient' or @Role='patient'                        
----     
----insert into Patient(PFname,PLname,PEmail,PDob,Patphoneno)          
----Output inserted.PId into @Ptblid      
----select Fname,Lname,Email,Dob,Phoneno from Register      
    
     
    
       
---- if @Role='Doctor' or @Role = 'doctor'             
----select @RCode='D-23100'+cast(RId as varchar(100)) from Register where RId in (select rid from @tblid)        
    
----insert into Doctor(DFname,DLname,Email,DDob,Dphone)          
----Output inserted.DId into @Dtblid           
----select Fname,Lname,Email,Dob,phoneno from Register where @Role = 'doctor' or @Role ='Doctor'     
    
    
        
    
    
---- if @Role='Staff'  or @Role = 'staff'                      
----select @RCode='S-23100'+cast(RId as varchar(100)) from Register where RId in (select rid from @tblid)           
    
----Update Register set  RCode=@RCode where RId in (select rid from @tblid)                 
----Update Personaldetails set PerCode =@PerCode, RCode=@RCode where PerId in (select PerId from @Pertblid)     
----Update Patient Set PerCode=@PerCode, RCode=@RCode where PId in (select PId from @Ptblid)     
----Update Doctor Set PerCode=@PerCode, RCode=@RCode where DId in (select DId from @Dtblid)    
    
end 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePassword_SP]    Script Date: 13-12-2023 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdatePassword_SP] @RPassword nvarchar(100), @CRPassword nvarchar(100),@Email nvarchar(100)          
as          
begin          
declare @count int      
select @count=count(*) from Register where Email=@Email              
if @count>0          
begin             
select  RId,RCode,Fname,Lname,Email,Password,CPassword,Username,Dob,Phoneno,Status,Role,1 as LStatus from Register      
where Email=@Email       
update Register set Password=@RPassword, CPassword=@CRPassword  Where  Email=@Email      
end        
else      
select 0 as LStatus       
end
GO
