USE [master]
GO
/****** Object:  Database [Pukimoni]    Script Date: 8/30/2023 8:24:08 PM ******/
CREATE DATABASE [Pukimoni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pukimoni', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pukimoni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pukimoni_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pukimoni_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pukimoni] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pukimoni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pukimoni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pukimoni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pukimoni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pukimoni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pukimoni] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pukimoni] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Pukimoni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pukimoni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pukimoni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pukimoni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pukimoni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pukimoni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pukimoni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pukimoni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pukimoni] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Pukimoni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pukimoni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pukimoni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pukimoni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pukimoni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pukimoni] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Pukimoni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pukimoni] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pukimoni] SET  MULTI_USER 
GO
ALTER DATABASE [Pukimoni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pukimoni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pukimoni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pukimoni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pukimoni] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pukimoni] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Pukimoni] SET QUERY_STORE = OFF
GO
USE [Pukimoni]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElementTypes]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElementTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_ElementTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](max) NULL,
	[Alt] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](450) NOT NULL,
	[UserId] [int] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[ExecutedOn] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[IsAuthorized] [bit] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pokedexs]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pokedexs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[PokemonId] [int] NOT NULL,
	[AmountCaught] [int] NOT NULL,
	[AmountCaughtShiny] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Pokedexs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PokemonElementTypes]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PokemonElementTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PokemonId] [int] NOT NULL,
	[ElementTypeId] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_PokemonElementTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pokemons]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pokemons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[Number] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ImageId] [int] NOT NULL,
	[EvolutionId] [int] NULL,
	[RegionId] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Pokemons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PokemonTrainers]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PokemonTrainers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[PokemonId] [int] NOT NULL,
	[Atk] [int] NOT NULL,
	[Def] [int] NOT NULL,
	[Cp] [int] NOT NULL,
	[Shiny] [bit] NOT NULL,
	[Favorite] [bit] NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_PokemonTrainers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/30/2023 8:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Blacklisted] [bit] NOT NULL,
	[NumberOfUsernameChanges] [int] NULL,
	[RoleId] [int] NOT NULL,
	[LastLogin] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[EntityStatus] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230830173624_MigiPlsPoslednji', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[ElementTypes] ON 

INSERT [dbo].[ElementTypes] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'Water', N'Water-type moves are super-effective against Fire-, Ground-, and Rock-type Pokémon, while Water-type Pokémon are weak to Electric- and Grass-type moves', N'Anon', CAST(N'2023-08-30T17:45:26.6783926' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ElementTypes] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'Grass', N'Grass-type moves are super-effective against Ground-, Rock-, and Water-type Pokémon, while Grass-type Pokémon are weak to Bug-, Fire-, Flying-, Ice-, and Poison-type moves.', N'Anon', CAST(N'2023-08-30T17:45:26.6783919' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ElementTypes] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, N'Fire', N'Fire-type moves are super-effective against Bug-, Grass-, Ice-, and Steel-type Pokémon, while Fire-type Pokémon are weak to Ground-, Rock-, and Water-type moves.', N'Anon', CAST(N'2023-08-30T17:45:26.6783934' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ElementTypes] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (4, N'Poison', N'Poison-type moves are super-effective against Fairy- and Grass-type Pokémon, while Poison-type Pokémon are weak to Ground- and Psychic-type moves.', N'Anon', CAST(N'2023-08-30T17:45:26.6783937' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[ElementTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Path], [Alt], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'001.png', N'Bulbasaur', N'Anon', CAST(N'2023-08-30T17:45:26.6783669' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Images] ([Id], [Path], [Alt], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'003.png', N'Venosaur', N'Anon', CAST(N'2023-08-30T17:45:26.6783715' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Images] ([Id], [Path], [Alt], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, N'002.png', N'Ivysaur', N'Anon', CAST(N'2023-08-30T17:45:26.6783709' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [Action], [UserId], [Username], [ExecutedOn], [Data], [IsAuthorized]) VALUES (1, N'GetPokemons', 2, N'kristina.nanuseski@gmail.com', CAST(N'2023-08-30T17:45:43.4777591' AS DateTime2), N'{"Page":1,"PerPage":10,"Keyword":"saur","SortBy":null}', 1)
INSERT [dbo].[Logs] ([Id], [Action], [UserId], [Username], [ExecutedOn], [Data], [IsAuthorized]) VALUES (2, N'GetPokemons', 2, N'kristina.nanuseski@gmail.com', CAST(N'2023-08-30T17:46:04.6536251' AS DateTime2), N'{"Page":1,"PerPage":10,"Keyword":"saur","SortBy":null}', 1)
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'GetUsers', N'Get all users', N'Anon', CAST(N'2023-08-30T17:45:25.9120496' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'GetUser', N'Get a user', N'Anon', CAST(N'2023-08-30T17:45:25.9480261' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, N'GetRegions', N'Get details of regions', N'Anon', CAST(N'2023-08-30T17:45:25.9580082' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (4, N'GetRegion', N'Get details of a region', N'Anon', CAST(N'2023-08-30T17:45:25.9628338' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (5, N'GetPokemonsTrainers', N'Get list of pokemon that a trainer has', N'Anon', CAST(N'2023-08-30T17:45:25.9649038' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (6, N'GetPokemons', N'Get all pokemon', N'Anon', CAST(N'2023-08-30T17:45:25.9671113' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (7, N'GetPokemon', N'Get a pokemonr', N'Anon', CAST(N'2023-08-30T17:45:25.9735152' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (8, N'GetElementTypes', N'Get details of a pokemon types', N'Anon', CAST(N'2023-08-30T17:45:25.9763613' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (9, N'GetElementType', N'Get details of a pokemon type', N'Anon', CAST(N'2023-08-30T17:45:25.9786566' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (10, N'UpdateUser', N'Update a username and/or password', N'Anon', CAST(N'2023-08-30T17:45:25.9809996' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (11, N'UpdateRegion', N'Update a region', N'Anon', CAST(N'2023-08-30T17:45:25.9834163' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (12, N'UpdatePokemon', N'Update a pokemon', N'Anon', CAST(N'2023-08-30T17:45:25.9883238' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (13, N'UpdateElementType', N'Update a pokemon type', N'Anon', CAST(N'2023-08-30T17:45:25.9928105' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (14, N'Transfer Pokemon', N'Transfer a Pokemon to the professor', N'Anon', CAST(N'2023-08-30T17:45:25.9955314' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (15, N'FavoritePokemon', N'Favorite pokemon toggle', N'Anon', CAST(N'2023-08-30T17:45:25.9983848' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (16, N'DeleteTrainer', N'Delete a trainer', N'Anon', CAST(N'2023-08-30T17:45:26.0015699' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (17, N'DeleteRegion', N'SoftDelete a region', N'Anon', CAST(N'2023-08-30T17:45:26.0100394' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (18, N'DeletePokemon', N'SoftDelete a pokemon', N'Anon', CAST(N'2023-08-30T17:45:26.0147083' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (19, N'DeleteElementType', N'SoftDelete a pokemon type', N'Anon', CAST(N'2023-08-30T17:45:26.0184219' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (20, N'CreateUser', N'Create a trainer', N'Anon', CAST(N'2023-08-30T17:45:26.0254502' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (21, N'CreateRegion', N'Create a new region', N'Anon', CAST(N'2023-08-30T17:45:26.0283229' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (22, N'CreatePokemon', N'Create a pokemon', N'Anon', CAST(N'2023-08-30T17:45:26.0317926' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (23, N'CreateElementType', N'Create a new pokemon type', N'Anon', CAST(N'2023-08-30T17:45:26.0398318' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (24, N'CatchPokemon', N'Catch a pokemon', N'Anon', CAST(N'2023-08-30T17:45:26.0466141' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (25, N'BanUser', N'Ban a user', N'Anon', CAST(N'2023-08-30T17:45:26.0513675' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (26, N'GetLogs', N'Get all logs', N'Anon', CAST(N'2023-08-30T17:45:26.0611358' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Pokedexs] ON 

INSERT [dbo].[Pokedexs] ([Id], [TrainerId], [PokemonId], [AmountCaught], [AmountCaughtShiny], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, 2, 3, 2, 0, N'Anon', CAST(N'2023-08-30T17:45:26.6784044' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Pokedexs] OFF
GO
SET IDENTITY_INSERT [dbo].[PokemonElementTypes] ON 

INSERT [dbo].[PokemonElementTypes] ([Id], [PokemonId], [ElementTypeId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, 1, 2, N'Anon', CAST(N'2023-08-30T17:45:26.6784011' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[PokemonElementTypes] ([Id], [PokemonId], [ElementTypeId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, 1, 4, N'Anon', CAST(N'2023-08-30T17:45:26.6784016' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[PokemonElementTypes] ([Id], [PokemonId], [ElementTypeId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, 2, 2, N'Anon', CAST(N'2023-08-30T17:45:26.6784020' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[PokemonElementTypes] ([Id], [PokemonId], [ElementTypeId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (4, 2, 4, N'Anon', CAST(N'2023-08-30T17:45:26.6784023' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[PokemonElementTypes] ([Id], [PokemonId], [ElementTypeId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (5, 3, 2, N'Anon', CAST(N'2023-08-30T17:45:26.6784028' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[PokemonElementTypes] ([Id], [PokemonId], [ElementTypeId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (6, 3, 4, N'Anon', CAST(N'2023-08-30T17:45:26.6784031' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[PokemonElementTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Pokemons] ON 

INSERT [dbo].[Pokemons] ([Id], [Name], [Number], [Description], [ImageId], [EvolutionId], [RegionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'Venusaur', 3, N'Venusaur, the final form of the Bulbasaur evolution. This Seed Pokémon soaks up the sun''s rays as a source of energy.', 2, NULL, 6, N'Anon', CAST(N'2023-08-30T17:45:26.6783991' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Pokemons] ([Id], [Name], [Number], [Description], [ImageId], [EvolutionId], [RegionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'Ivysaur', 2, N'The Seed Pokémon, Ivysaur, Bulbasaur''s evolved form. The bulb on its back absorbs nourishment and blooms into a large flower.', 3, 1, 6, N'Anon', CAST(N'2023-08-30T17:45:26.6783997' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Pokemons] ([Id], [Name], [Number], [Description], [ImageId], [EvolutionId], [RegionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, N'Bulbasaur', 1, N'Bulbasaur. It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely tough and very difficult to capture in the wild.', 1, 2, 6, N'Anon', CAST(N'2023-08-30T17:45:26.6784003' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Pokemons] OFF
GO
SET IDENTITY_INSERT [dbo].[PokemonTrainers] ON 

INSERT [dbo].[PokemonTrainers] ([Id], [TrainerId], [PokemonId], [Atk], [Def], [Cp], [Shiny], [Favorite], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, 2, 3, 3, 3, 10000, 0, 0, N'Anon', CAST(N'2023-08-30T17:45:26.6784036' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[PokemonTrainers] ([Id], [TrainerId], [PokemonId], [Atk], [Def], [Cp], [Shiny], [Favorite], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, 2, 3, 33, 33, 3300, 0, 0, N'Anon', CAST(N'2023-08-30T17:45:26.6784041' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[PokemonTrainers] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'Kalos', N'The Kalos region is the setting of the sixth generation of Pokémon games, which is where the games Pokémon X and Y take place. This region is inspired almost entirely by the northern half of Metropolitan France, with landmarks such as the Eiffel Tower and the Palace of Versailles having representations here, along with a French style of music and fashion. According to Junichi Masuda, the name ''Kalos'' comes from the Ancient Greek word κάλλος, ''beauty''. The Kalos Pokémon League is based on the Notre-Dame de Paris due to its castle/cathedral-like exterior.', N'Anon', CAST(N'2023-08-30T17:45:26.6783962' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'Unova', N'The Unova region is the setting of the fifth generation of Pokémon games, which encompasses the setting of Pokémon Black and White and their sequels Pokémon Black 2 and White 2. For the first time in the main series, the region was based on a region outside Japan, with Unova taking inspiration from the New York metropolitan area.', N'Anon', CAST(N'2023-08-30T17:45:26.6783959' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, N'Sinnoh', N'The Sinnoh region is the setting of the fourth generation of Pokémon games, which encompasses the setting of Pokémon Diamond, Pearl and Platinum, as well as their remakes Pokémon Brilliant Diamond and Shining Pearl and Pokémon Legends: Arceus.It is based on the northernmost island of Japan, Hokkaidō. The region was meant to have a ''northern'' feel, with some routes being entirely covered in snow.', N'Anon', CAST(N'2023-08-30T17:45:26.6783955' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (4, N'Hoenn', N'The Hoenn region is the setting of the third generation of Pokémon games, Pokémon Ruby, Sapphire and Emerald, as well as their remakes Pokémon Omega Ruby and Alpha Sapphire. This time being based on the Japanese island of Kyushu; the real world and game region share an abundance of smaller islands around the main one and a subtropical climate. Like Sinnoh, this region is known to have a large range of various natural environments, such as rainforests and deserts.', N'Anon', CAST(N'2023-08-30T17:45:26.6783952' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (5, N'Johto', N'The Johto region is the setting of the second generation of Pokémon games, which includes Pokémon Gold, Silver, Crystal and their remakes, Pokémon HeartGold and SoulSilver. Again, based on an area of Japan, this game''s geography is based upon the Kansai, Tokai and eastern Shikoku areas of the country. The game setting draws upon the Kansai region''s abundance of temples, the architectural design of the Kansai region and its geographical sights, such as Mount Fuji and the Naruto whirlpools.', N'Anon', CAST(N'2023-08-30T17:45:26.6783948' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (6, N'Kanto', N'The Kanto region is the setting of Pokémon Red, Blue, and Yellow and their remakes, Pokémon FireRed, LeafGreen, Let''s Go, Pikachu! and Let''s Go, Eevee!. Based on and named after the Kantō region of Japan, this setting started the precedent of basing the geography and culture of the game''s region on a real-world setting. This region is also visited in Pokémon Gold, Silver, Crystal, HeartGold and SoulSilver.', N'Anon', CAST(N'2023-08-30T17:45:26.6783942' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (7, N'Galar', N'The Galar region is the setting of the eighth generation of Pokémon games, which is where the games Pokémon Sword and Shield take place. This region is primarily inspired by Great Britain (mainly England and parts of Scotland), showcasing landmarks inspired by Big Ben and Hadrian''s Wall. Two additional areas, The Isle of Armor and The Crown Tundra, are based on the Isle of Man and Scotland respectively. The Galar Region was also introduced in Pokémon Journeys.', N'Anon', CAST(N'2023-08-30T17:45:26.6783976' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Regions] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (8, N'Alola', N'The Alola region is the setting of the seventh generation of Pokémon games, Pokémon Sun, Moon, Ultra Sun and Ultra Moon. This region is based on Hawaii, marking the second time a main entry Pokémon game setting has been inspired by a U.S. state. The name itself is a play on aloha, the Hawaiian word for both ''hello'' and ''goodbye''.', N'Anon', CAST(N'2023-08-30T17:45:26.6783970' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[RolePermissions] ON 

INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, 2, 17, N'Anon', CAST(N'2023-08-30T17:45:26.6783869' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, 1, 18, N'Anon', CAST(N'2023-08-30T17:45:26.6783874' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (3, 1, 19, N'Anon', CAST(N'2023-08-30T17:45:26.6783877' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (4, 1, 20, N'Anon', CAST(N'2023-08-30T17:45:26.6783882' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (5, 1, 21, N'Anon', CAST(N'2023-08-30T17:45:26.6783886' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (6, 2, 25, N'Anon', CAST(N'2023-08-30T17:45:26.6783908' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (7, 1, 23, N'Anon', CAST(N'2023-08-30T17:45:26.6783896' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (8, 1, 24, N'Anon', CAST(N'2023-08-30T17:45:26.6783900' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (9, 1, 25, N'Anon', CAST(N'2023-08-30T17:45:26.6783904' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (10, 1, 26, N'Anon', CAST(N'2023-08-30T17:45:26.6783912' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (11, 1, 17, N'Anon', CAST(N'2023-08-30T17:45:26.6783866' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (12, 1, 22, N'Anon', CAST(N'2023-08-30T17:45:26.6783892' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (13, 2, 16, N'Anon', CAST(N'2023-08-30T17:45:26.6783861' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (14, 2, 15, N'Anon', CAST(N'2023-08-30T17:45:26.6783853' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (15, 1, 7, N'Anon', CAST(N'2023-08-30T17:45:26.6783781' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (16, 2, 2, N'Anon', CAST(N'2023-08-30T17:45:26.6783736' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (17, 1, 3, N'Anon', CAST(N'2023-08-30T17:45:26.6783741' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (18, 2, 3, N'Anon', CAST(N'2023-08-30T17:45:26.6783746' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (19, 1, 4, N'Anon', CAST(N'2023-08-30T17:45:26.6783752' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (20, 2, 4, N'Anon', CAST(N'2023-08-30T17:45:26.6783758' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (21, 1, 5, N'Anon', CAST(N'2023-08-30T17:45:26.6783764' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (22, 2, 5, N'Anon', CAST(N'2023-08-30T17:45:26.6783768' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (23, 1, 6, N'Anon', CAST(N'2023-08-30T17:45:26.6783771' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (24, 2, 6, N'Anon', CAST(N'2023-08-30T17:45:26.6783775' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (25, 1, 16, N'Anon', CAST(N'2023-08-30T17:45:26.6783857' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (26, 1, 2, N'Anon', CAST(N'2023-08-30T17:45:26.6783728' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (27, 2, 7, N'Anon', CAST(N'2023-08-30T17:45:26.6783786' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (28, 2, 8, N'Anon', CAST(N'2023-08-30T17:45:26.6783795' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (29, 1, 9, N'Anon', CAST(N'2023-08-30T17:45:26.6783800' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (30, 2, 9, N'Anon', CAST(N'2023-08-30T17:45:26.6783806' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (31, 1, 10, N'Anon', CAST(N'2023-08-30T17:45:26.6783814' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (32, 2, 10, N'Anon', CAST(N'2023-08-30T17:45:26.6783819' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (33, 1, 11, N'Anon', CAST(N'2023-08-30T17:45:26.6783823' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (34, 1, 12, N'Anon', CAST(N'2023-08-30T17:45:26.6783832' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (35, 1, 13, N'Anon', CAST(N'2023-08-30T17:45:26.6783836' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (36, 1, 14, N'Anon', CAST(N'2023-08-30T17:45:26.6783841' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (37, 1, 15, N'Anon', CAST(N'2023-08-30T17:45:26.6783845' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (38, 1, 8, N'Anon', CAST(N'2023-08-30T17:45:26.6783791' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[RolePermissions] ([Id], [RoleId], [PermissionId], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (39, 1, 1, N'Anon', CAST(N'2023-08-30T17:45:26.6783720' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[RolePermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'Admin', N'This role can do everything.', N'Anon', CAST(N'2023-08-30T17:45:25.4763208' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'Trainer', N'This role can only interact with Pokemon.', N'Anon', CAST(N'2023-08-30T17:45:25.8568727' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Email], [Password], [Blacklisted], [NumberOfUsernameChanges], [RoleId], [LastLogin], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (1, N'Nanuseski', N'kristina.nanuseski.3.18@ict.edu.rs', N'$2a$11$mwUqA6C.x/mPc.pkXAxWPeQCtim9fEp1HlPns/Z2WqCgHDEnzDRey', 0, 0, 1, NULL, N'Anon', CAST(N'2023-08-30T17:45:26.6783981' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Users] ([Id], [Username], [Email], [Password], [Blacklisted], [NumberOfUsernameChanges], [RoleId], [LastLogin], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EntityStatus]) VALUES (2, N'Nanuki', N'kristina.nanuseski@gmail.com', N'$2a$11$mwUqA6C.x/mPc.pkXAxWPeQCtim9fEp1HlPns/Z2WqCgHDEnzDRey', 0, 0, 2, NULL, N'Anon', CAST(N'2023-08-30T17:45:26.6783985' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ElementTypes_Name]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ElementTypes_Name] ON [dbo].[ElementTypes]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Logs_Action]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Logs_Action] ON [dbo].[Logs]
(
	[Action] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Permissions_Name]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Permissions_Name] ON [dbo].[Permissions]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pokedexs_PokemonId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pokedexs_PokemonId] ON [dbo].[Pokedexs]
(
	[PokemonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pokedexs_TrainerId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pokedexs_TrainerId] ON [dbo].[Pokedexs]
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PokemonElementTypes_ElementTypeId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PokemonElementTypes_ElementTypeId] ON [dbo].[PokemonElementTypes]
(
	[ElementTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PokemonElementTypes_PokemonId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PokemonElementTypes_PokemonId] ON [dbo].[PokemonElementTypes]
(
	[PokemonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pokemons_EvolutionId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pokemons_EvolutionId] ON [dbo].[Pokemons]
(
	[EvolutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pokemons_ImageId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pokemons_ImageId] ON [dbo].[Pokemons]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Pokemons_Name]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pokemons_Name] ON [dbo].[Pokemons]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pokemons_Number]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pokemons_Number] ON [dbo].[Pokemons]
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pokemons_RegionId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pokemons_RegionId] ON [dbo].[Pokemons]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PokemonTrainers_PokemonId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PokemonTrainers_PokemonId] ON [dbo].[PokemonTrainers]
(
	[PokemonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PokemonTrainers_TrainerId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_PokemonTrainers_TrainerId] ON [dbo].[PokemonTrainers]
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Regions_Name]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Regions_Name] ON [dbo].[Regions]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolePermissions_PermissionId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_RolePermissions_PermissionId] ON [dbo].[RolePermissions]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolePermissions_RoleId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_RolePermissions_RoleId] ON [dbo].[RolePermissions]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Roles_Name]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Roles_Name] ON [dbo].[Roles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 8/30/2023 8:24:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pokedexs]  WITH CHECK ADD  CONSTRAINT [FK_Pokedexs_Pokemons_PokemonId] FOREIGN KEY([PokemonId])
REFERENCES [dbo].[Pokemons] ([Id])
GO
ALTER TABLE [dbo].[Pokedexs] CHECK CONSTRAINT [FK_Pokedexs_Pokemons_PokemonId]
GO
ALTER TABLE [dbo].[Pokedexs]  WITH CHECK ADD  CONSTRAINT [FK_Pokedexs_Users_TrainerId] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Pokedexs] CHECK CONSTRAINT [FK_Pokedexs_Users_TrainerId]
GO
ALTER TABLE [dbo].[PokemonElementTypes]  WITH CHECK ADD  CONSTRAINT [FK_PokemonElementTypes_ElementTypes_ElementTypeId] FOREIGN KEY([ElementTypeId])
REFERENCES [dbo].[ElementTypes] ([Id])
GO
ALTER TABLE [dbo].[PokemonElementTypes] CHECK CONSTRAINT [FK_PokemonElementTypes_ElementTypes_ElementTypeId]
GO
ALTER TABLE [dbo].[PokemonElementTypes]  WITH CHECK ADD  CONSTRAINT [FK_PokemonElementTypes_Pokemons_PokemonId] FOREIGN KEY([PokemonId])
REFERENCES [dbo].[Pokemons] ([Id])
GO
ALTER TABLE [dbo].[PokemonElementTypes] CHECK CONSTRAINT [FK_PokemonElementTypes_Pokemons_PokemonId]
GO
ALTER TABLE [dbo].[Pokemons]  WITH CHECK ADD  CONSTRAINT [FK_Pokemons_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Pokemons] CHECK CONSTRAINT [FK_Pokemons_Images_ImageId]
GO
ALTER TABLE [dbo].[Pokemons]  WITH CHECK ADD  CONSTRAINT [FK_Pokemons_Pokemons_EvolutionId] FOREIGN KEY([EvolutionId])
REFERENCES [dbo].[Pokemons] ([Id])
GO
ALTER TABLE [dbo].[Pokemons] CHECK CONSTRAINT [FK_Pokemons_Pokemons_EvolutionId]
GO
ALTER TABLE [dbo].[Pokemons]  WITH CHECK ADD  CONSTRAINT [FK_Pokemons_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[Pokemons] CHECK CONSTRAINT [FK_Pokemons_Regions_RegionId]
GO
ALTER TABLE [dbo].[PokemonTrainers]  WITH CHECK ADD  CONSTRAINT [FK_PokemonTrainers_Pokemons_PokemonId] FOREIGN KEY([PokemonId])
REFERENCES [dbo].[Pokemons] ([Id])
GO
ALTER TABLE [dbo].[PokemonTrainers] CHECK CONSTRAINT [FK_PokemonTrainers_Pokemons_PokemonId]
GO
ALTER TABLE [dbo].[PokemonTrainers]  WITH CHECK ADD  CONSTRAINT [FK_PokemonTrainers_Users_TrainerId] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PokemonTrainers] CHECK CONSTRAINT [FK_PokemonTrainers_Users_TrainerId]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permissions_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permissions_PermissionId]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles_RoleId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Pukimoni] SET  READ_WRITE 
GO
