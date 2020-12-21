



CREATE TABLE [dbo].[Employees](
	[EmployeeMetadaId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeTypeId] [int] not null,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address1] [varchar](100) NULL,
	[PayScaleId] int not null, 
	[ManagerPayId] int not null
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PayScale](
	[PayScaleId] [int] IDENTITY(1,1) NOT NULL,
	[PayTypeId] [int] NOT NULL,
	[PayValue] [decimal](5, 2) NOT NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ManagerPay](
	[ManagerPayId] [int] IDENTITY(1,1) NOT NULL,
	[AnnualSalary] [decimal](10, 2) NOT NULL,
	[MaxExpenseAccount] [decimal](10, 2) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LU_PayType](
	[PayTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PayName] [varchar](30) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LU_EmployeeType](
	[EmployeeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
) ON [PRIMARY]
GO


ALTER TABLE Employees ADD CONSTRAINT FK_PayScale FOREIGN KEY (PayScaleId) REFERENCES PayScale(PayScaleId);
ALTER TABLE Employees ADD CONSTRAINT FK_ManagerPayId FOREIGN KEY (ManagerPayId) REFERENCES ManagerPay(ManagerPayId);

ALTER TABLE Employees ADD PRIMARY KEY (EmployeeMetadaId)
ALTER TABLE LU_PayType ADD PRIMARY KEY (PayTypeId)
ALTER TABLE PayScale ADD PRIMARY KEY (PayScaleId)
ALTER TABLE LU_EmployeeType ADD PRIMARY KEY (EmployeeTypeId)