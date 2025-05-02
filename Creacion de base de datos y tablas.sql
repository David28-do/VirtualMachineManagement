CREATE DATABASE VirtualMachineManagement;

-- Usar la base de datos creada
USE VirtualMachineManagement;

CREATE TABLE VirtualMachine (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Core NVARCHAR(50) NOT NULL,
    Ram NVARCHAR(50) NOT NULL,
    Disk NVARCHAR(50) NOT NULL,
    Os NVARCHAR(100) NOT NULL,
    Status bit NOT NULL
);

INSERT [dbo].VirtualMachine ([Name], [Core], [Ram], [Disk],[Os], [Status]) VALUES ('VM-Test-01','4 vCPU', '8 GB','256 GB SSD', 'Windows Server 2022', 1)
INSERT [dbo].VirtualMachine ([Name], [Core], [Ram], [Disk],[Os],[Status]) VALUES ('VM-Test-02','6 vCPU', '16 GB','256 GB SSD', 'Windows Server 2022',0 )



CREATE TABLE [dbo].[Seguridad](
	[IdSeguridad] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Contrasena] [varchar](200) NOT NULL,
	[Rol] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/08/2021 1:50:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuID] [int] IDENTITY(1,1) NOT NULL,
	[UsuNombre] [varchar](50) NOT NULL,
	[UsuPass] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET IDENTITY_INSERT [dbo].[Seguridad] ON 

INSERT [dbo].[Seguridad] ([IdSeguridad], [Usuario], [NombreUsuario], [Contrasena], [Rol]) VALUES (1, N'Admin', N'Administrador', N'1234', N'Administrador')
INSERT [dbo].[Seguridad] ([IdSeguridad], [Usuario], [NombreUsuario], [Contrasena], [Rol]) VALUES (2, N'Delev', N'Developer', N'98745', N'Developer')
SET IDENTITY_INSERT [dbo].[Seguridad] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuID], [UsuNombre], [UsuPass]) VALUES (1, N'David Ramirez', N'xxxx')
INSERT [dbo].[Usuario] ([UsuID], [UsuNombre], [UsuPass]) VALUES (2, N'Leonardo Heredia', N'yyyy')
INSERT [dbo].[Usuario] ([UsuID], [UsuNombre], [UsuPass]) VALUES (3, N'Andres Fernandez', N'qqqqqq')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO