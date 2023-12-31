USE [zencareservice]
GO
/****** Object:  Table [dbo].[DocumentcodeTbl]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  View [dbo].[Documentcode_vw]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Documentcode_vw]
as
select Seriesname,Keyword+RIGHT(REPLICATE('0', PadNo) + cast(CurrentNo+1 as varchar(100)), PadNo) as docno 
from DocumentcodeTbl
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 19-12-2023 19:38:43 ******/
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
	[UsrId] [int] NULL,
 CONSTRAINT [AptCode] UNIQUE NONCLUSTERED 
(
	[AptCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointmentstatus]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Appointmentstatus_tbl]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[City_tbl]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City_tbl](
	[CId] [int] IDENTITY(1,1) NOT NULL,
	[CCode] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[SId] [int] NULL,
	[State] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 19-12-2023 19:38:43 ******/
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
	[Dphone] [varchar](14) NULL,
	[ADphone] [varchar](14) NULL,
	[Practionerproof] [varbinary](max) NULL,
	[Dphoto] [varbinary](max) NULL,
	[Dexp] [varchar](12) NULL,
	[Dqualification] [varchar](255) NULL,
	[Dspecialist] [varchar](255) NULL,
	[DDob] [date] NULL,
	[UsrId] [int] NULL,
	[Daddress1] [varchar](255) NULL,
	[Daddress2] [varchar](255) NULL,
	[DCity] [varchar](255) NULL,
	[Duniqueid] [varchar](255) NULL,
 CONSTRAINT [UQ_Doctor_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctorspecialist_tbl]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[logindate] [datetime] NULL,
	[lastlogin] [datetime] NULL,
	[Fname] [varchar](255) NULL,
	[Lname] [varchar](255) NULL,
	[RCode] [varchar](255) NULL,
	[Dob] [datetime] NULL,
	[Role] [nvarchar](255) NULL,
	[Password] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module_tbl]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module_tbl](
	[SNo] [int] NULL,
	[Modulename] [varchar](255) NULL,
	[Controller] [varchar](255) NULL,
	[Action] [varchar](255) NULL,
	[MRole] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modules]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Patdiagnosis]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Patient]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PId] [int] IDENTITY(1,1) NOT NULL,
	[RCode] [varchar](255) NULL,
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
	[Puniqueid] [varchar](255) NULL,
	[PState] [varchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patientdetails]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Permissions]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Personaldetails]    Script Date: 19-12-2023 19:38:43 ******/
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
	[Addressline2] [nvarchar](max) NULL,
	[AltAddress] [nvarchar](max) NULL,
	[State] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[Photo] [varbinary](max) NULL,
	[UsrId] [int] NULL,
	[Dob] [datetime] NULL,
	[Role] [varchar](255) NULL,
	[Addressline1] [nvarchar](100) NULL,
	[Zipcode] [varchar](6) NULL,
	[Updatedate] [date] NULL,
 CONSTRAINT [UQ_Personaldetails_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Register]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Rolerights_tbl]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rolerights_tbl](
	[SNo] [int] NULL,
	[UsrId] [int] NULL,
	[UsrName] [varchar](100) NULL,
	[RoleId] [int] NULL,
	[RoleName] [varchar](255) NULL,
	[ModuleId] [int] NULL,
	[ModuleName] [varchar](255) NULL,
	[Rights] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  Table [dbo].[Staff]    Script Date: 19-12-2023 19:38:43 ******/
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
	[SDob] [datetime] NULL,
	[Saphoneno] [varchar](20) NULL,
	[Saddress1] [varchar](255) NULL,
	[Saddress2] [varchar](255) NULL,
	[SCity] [varchar](255) NULL,
	[Sphoto] [varbinary](max) NULL,
	[Suniqueid] [varchar](25) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State_tbl]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State_tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SCode] [varchar](255) NULL,
	[State] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatment]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  StoredProcedure [dbo].[AppointmentBooking_SP]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AppointmentBooking_SP] @PatientFirstname nvarchar(255),@PatientLastname varchar(255),@PatientEmail varchar(255),@DoctorFirstname varchar(255),@DoctorLastname varchar(255),                            
@AptBookdate date,@AptTime time,@ReasonType  varchar(255), @RCode varchar(255),                       
@Patgender varchar(255)           
                          
as                                
begin                             
declare  @AptCode nvarchar(100)                 
declare @count int                            
declare @tblid Table(AptId int)                
                            
    
        
insert into Appointment(RCode,Reasontype,PatientEmail,PFname,PLname,Patgender,DFname,DLname,AptBookingdate,AptTime,Aptcreatedate)                             
Output inserted.AptId into @tblid                                        
values(@RCode,@ReasonType,@PatientEmail,@PatientFirstname,@PatientLastname,@Patgender,@DoctorFirstname,@DoctorLastname,@AptBookdate,@Apttime,getdate())                               
select @AptCode='APT-100'+cast(AptId as varchar(100)) from Appointment where AptId in (select AptId from @tblid)    
Update Appointment set AptCode=@AptCode where AptId in (select AptId from @tblid)      
UPDATE Appointment
SET
	Patgender = (SELECT Patgender from Patient  WHERE Appointment.RCode= Patient.RCode),
    Pataddress1 = (SELECT Pataddress1 FROM Patient WHERE Appointment.RCode= Patient.RCode),
    Pataddress2 = (SELECT Pataddress2 FROM Patient WHERE Appointment.RCode= Patient.RCode),
    PState = (SELECT PState FROM Patient WHERE Appointment.RCode= Patient.RCode),
	PCity = (SELECT PCity FROM Patient WHERE Appointment.RCode= Patient.RCode),
	PatPhone = (SELECT Patphone FROM Patient WHERE Appointment.RCode= Patient.RCode),
	Patage = (SELECT Patage FROM Patient WHERE Appointment.RCode= Patient.RCode)
 WHERE AptId in (select AptId from @tblid);   
end
GO
/****** Object:  StoredProcedure [dbo].[AuthenticateUser]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  StoredProcedure [dbo].[CalculateAge]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalculateAge]
    @DateOfBirth DATE
AS
BEGIN
    -- Get the current date
    DECLARE @CurrentDate DATE
    SET @CurrentDate = GETDATE();

    -- Calculate the age using DATEDIFF
    DECLARE @Age INT
    SET @Age = DATEDIFF(YEAR, @DateOfBirth, @CurrentDate) -
               CASE
                   WHEN @DateOfBirth > DATEADD(YEAR, DATEDIFF(YEAR, @DateOfBirth, @CurrentDate), @DateOfBirth) THEN 1
                   ELSE 0
               END

    -- Display the result
    SELECT
        @DateOfBirth AS DateOfBirth,
        @CurrentDate AS CurrentDate,
        @Age AS Age
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckLogin_SP]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CheckLogin_SP] @Uname nvarchar(100),@Pass nvarchar(100) as        
begin                
declare @count int                
declare @LL datetime                
declare @UsrId int
declare @Role nvarchar(100)
select @count=count(*) from Register where Username=@Uname or Email=@Uname and Password=@Pass           
if @count>0                
begin                
select @LL=Logindate from login where lid in  (select max(LId) from login where  Username=@Uname and Password=@Pass)                
insert into login(Fname,Lname,Username, Password,Email,logindate,lastlogin,RCode,Dob,Role)                  
select Fname,Lname, Username,Password,Email,getdate(),@LL,RCode,Dob,Role from Register where Username=@Uname or Email=@Uname and Password=@Pass               
            
select RId,RCode,Fname,Lname,Email,Password,CPassword,Username,Dob,Phoneno,Status,Role,1 as LStatus from Register            
where Username=@Uname  or Email=@Uname and Password=@Pass             
            
            
end              
else            
select 0 as LStatus   
select @UsrId =RId,@Role=Role from Register where Username=@Uname  or Email=@Uname and Password=@Pass             

if @Role='Staff'
select 'Dashboard' as Modulename,'Reports' as Controller,'DashboardV1' as Action,1 as Rights
union all
select a.Modulename,a.Controller,a.Action,b.Rights from Module_tbl a,Rolerights_tbl b where a.Modulename=b.ModuleName 
and UsrId=@UsrId 

else
select 'Dashboard' as Modulename,'Reports' as Controller,'DashboardV2' as Action,1 as Rights
union all
select a.Modulename,a.Controller,a.Action,b.Rights from Module_tbl a,Rolerights_tbl b where a.Modulename=b.ModuleName 
and UsrId=@UsrId 

            
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllAppoinments]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAppoinments] @UsrId int          
          
AS          
          
BEGIN          
          
      SET NOCOUNT ON;          
          
      SELECT * FROM Appointment where UsrId=@UsrId     
     
   select RCode,Fname,Lname,Email,Phoneno,Gender,Addressline1,Age FROM Personaldetails  
        
   select DId, DFname,DLname from Doctor  
  
   Select Id, State from State_tbl        
          
END 
GO
/****** Object:  StoredProcedure [dbo].[GetAllCitites]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCitites] @StateId int  
  
AS  
  
BEGIN  
  
      SET NOCOUNT ON;  
  
      SELECT CId, City 
  
      FROM City_tbl where SId=@StateId 

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmaildetails]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmaildetails] @Email varchar(255)  
    
AS    
    
BEGIN    
    
      SET NOCOUNT ON;    
    
      SELECT * from Register where Email =@Email  
	  SELECT * from Personaldetails where Email =@Email
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPersonalDetails]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPersonalDetails] @UsrId int    
    
AS    
    
BEGIN    
    
      SET NOCOUNT ON;    
    
      SELECT * FROM Personaldetails where UsrId=@UsrId    
  
   Select Id, State from State_tbl  
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStates]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStates]   
      
AS      
      
BEGIN      
      
      SET NOCOUNT ON;      
      
      SELECT * from State_tbl  

      
END
GO
/****** Object:  StoredProcedure [dbo].[GetModulesByRole]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  StoredProcedure [dbo].[Prescription_SP]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  StoredProcedure [dbo].[SaveRegister_SP]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SaveRegister_SP] @Firstname nvarchar(255),@Lastname varchar(255),@Email varchar(255),                                
@Password varchar(255),@ConfirmPassword varchar(255),@Username varchar(255),@Dob datetime,@Phone varchar(255),@Status int,                                
@Role varchar(255),@agreeterm int, @Age int      
                                     
as                                    
begin                                 
declare  @RCode nvarchar(100)                 
declare @PerCode nvarchar(100)               
declare @count int                                
declare @tblid Table(RId int)               
declare @Pertblid Table (PerId int)              
declare @Ptblid Table(PId int)                  
declare @Dtblid Table(DId int)           
declare @Stblid Table(SId int)      
--declare @CurrentDate DATE      
--set @CurrentDate = GETDATE();        
      
-- SET @Age = DATEDIFF(YEAR, @Dob, @CurrentDate) -      
--               CASE      
--                   WHEN @Dob > DATEADD(YEAR, DATEDIFF(YEAR, @Dob, @CurrentDate), @Dob) THEN 1      
--                   ELSE 0      
          
          
          
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
insert into Personaldetails(Fname,Lname,Email,Phoneno,Dob,UsrId,Role,PerCode,RCode,Age)                
Output inserted.PerId into @Pertblid              
values(@Firstname,@Lastname,@Email,@Phone,@Dob,@UId,@Role,@PerCode,@RCode,@Age)          
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Personaldetail'        
        
if (@Role='Patient')
BEGIN
declare @PUId int              
select @PUId=rid from @tblid       
insert into Patient(PFname,PLname,PEmail,Patphoneno,PDob,Percode,RCode,Patage,UsrId)      
Output inserted.PId into @Ptblid       
values(@Firstname,@Lastname,@Email,@Phone,@Dob,@PerCode,@RCode,@Age,@PUId)         
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Patient'        
END   
        
else if @Role ='Doctor'
Begin
declare @DUId int              
select @DUId=rid from @tblid    
insert into Doctor(DFname,DLname,Email,Dphone,DDob,Percode,RCode,Dage,UsrId)      
Output inserted.DId into @Dtblid       
values(@Firstname,@Lastname,@Email,@Phone,@Dob,@PerCode,@RCode,@Age,@DUId)       
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Doctor'        
end   
else if @Role='Staff'    
BEGIN
declare @SUId int              
select @SUId=rid from @tblid    
insert into Staff(SFname,SLname,SEmail,SPhone,SDob,Percode,RCode,Sage,UsrId)      
Output inserted.SId into @Stblid       
values(@Firstname,@Lastname,@Email,@Phone,@Dob,@PerCode,@RCode,@Age,@SUId)       
update DocumentcodeTbl set CurrentNo = CurrentNo +1 where Seriesname='Staff'        
END         
end
GO
/****** Object:  StoredProcedure [dbo].[UpdatePassword_SP]    Script Date: 19-12-2023 19:38:43 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdatePersonaldetails_SP]    Script Date: 19-12-2023 19:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdatePersonaldetails_SP] @Gender nvarchar(100),@APhoneno nvarchar(100),@Addressline1 nvarchar(100),@Addressline2 nvarchar(100),@AltAddress nvarchar(100),    
@State nvarchar(100),@City nvarchar(100),@Country nvarchar(100),@Email nvarchar(100),@UniqueId  nvarchar(100),@UsrId int,@Zipcode varchar(6),@Role varchar(20)            
as                
begin                
declare @count int            
select @count=count(*) from Personaldetails where UsrId=@UsrId                    
if @count>0                
begin                   
select * from Personaldetails  where Email=@Email  

update Personaldetails set Gender=@Gender, Aphoneno=@Aphoneno, State=@State, City=@City, Country=@Country, Addressline1=@Addressline1,UniqueId=@UniqueId,    
Addressline2=@Addressline2, AltAddress=@AltAddress,Zipcode=@Zipcode,Updatedate = getdate() Where  UsrId=@UsrId   or Email=@Email   

if @Role='Patient'
update Patient set PatGender=@Gender,Pataltphone=@Aphoneno,PEmail=@Email, PState=@State, PCity=@City, Pataddress1=@Addressline1,PUniqueId=@UniqueId,    
Pataddress2=@Addressline2  Where  UsrId=@UsrId  

if @Role='Doctor'

update Doctor set Dgender=@Gender,ADphone=@APhoneno,Daddress1=@Addressline1,Daddress2=@Addressline2,Duniqueid=@Uniqueid,DCity=@City where UsrId=@UsrId


end              
else          
   select 0 as LStatus       
end
GO
