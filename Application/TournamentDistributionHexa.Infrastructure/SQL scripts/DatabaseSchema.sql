SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Composition](
	[MatchId] [bigint] NOT NULL,
	[JeuId] [bigint] NOT NULL,
	[TournoiId] [bigint] NOT NULL,
 CONSTRAINT [PK_MatchTournoiJeu] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC,
	[JeuId] ASC,
	[TournoiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jeu]    Script Date: 06/12/2022 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jeu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](100) NOT NULL,
	[NbJoueursMin] [int] NOT NULL,
	[NbJoueursMax] [int] NOT NULL,
	[MecaniqueId] [bigint] NULL,
 CONSTRAINT [PK_Jeu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Joueur]    Script Date: 06/12/2022 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Joueur](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Joueur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 06/12/2022 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[DateFin] [datetime] NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mecanique]    Script Date: 06/12/2022 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mecanique](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Mecanique] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Score]    Script Date: 06/12/2022 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[MatchId] [bigint] NOT NULL,
	[JoueurId] [bigint] NOT NULL,
	[Points] [int] NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC,
	[JoueurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournoi]    Script Date: 06/12/2022 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournoi](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[DateDebut] [datetime] NULL,
	[DateFin] [datetime] NULL,
 CONSTRAINT [PK_Tournoi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (81, 1, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (82, 1, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (83, 1, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (84, 1, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (85, 2, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (86, 2, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (87, 2, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (88, 2, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (89, 3, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (90, 3, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (91, 3, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (92, 3, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (93, 4, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (94, 4, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (95, 4, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (96, 4, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (97, 5, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (98, 5, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (99, 5, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (100, 5, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (101, 6, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (102, 6, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (103, 6, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (104, 6, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (105, 7, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (106, 7, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (107, 7, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (108, 7, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (109, 8, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (110, 8, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (111, 8, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (112, 8, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (113, 9, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (114, 9, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (115, 9, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (116, 9, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (117, 10, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (118, 10, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (119, 10, 7)
GO
INSERT [dbo].[Composition] ([MatchId], [JeuId], [TournoiId]) VALUES (120, 10, 7)
GO
SET IDENTITY_INSERT [dbo].[Jeu] ON 
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (1, N'Ark Nova', 2, 4, 7)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (2, N'Akropolis', 2, 5, 6)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (3, N'Dune Imperium', 2, 4, 1)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (4, N'Zombidice', 2, 4, 2)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (5, N'Perudo', 2, 4, 5)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (6, N'L''âge de pierre', 2, 4, 4)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (7, N'Living forest', 2, 4, 8)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (8, N'Mille fiori', 2, 4, 3)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (9, N'Le jeu de la dame', 2, 7, 10)
GO
INSERT [dbo].[Jeu] ([Id], [Nom], [NbJoueursMin], [NbJoueursMax], [MecaniqueId]) VALUES (10, N'Augustus', 2, 8, 9)
GO
SET IDENTITY_INSERT [dbo].[Jeu] OFF
GO
SET IDENTITY_INSERT [dbo].[Joueur] ON 
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (1, N'Brandt', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (2, N'François', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (3, N'François', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (5, N'Rey', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (6, N'Cruchon', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (7, N'Pasdeloup', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (8, N'Olivier', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (11, N'Fernandes', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (12, N'Roussiale', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (13, N'Dieleman', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (14, N'Riquier', N'roger', N'0123456789')
GO
INSERT [dbo].[Joueur] ([Id], [Nom], [Prenom], [Telephone]) VALUES (15, N'Mauvezin', N'roger', N'0123456789')
GO
SET IDENTITY_INSERT [dbo].[Joueur] OFF
GO
SET IDENTITY_INSERT [dbo].[Match] ON 
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (81, N'Match 1', CAST(N'2022-11-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (82, N'Match 2', CAST(N'2022-10-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (83, N'Match 3', CAST(N'2022-11-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (84, N'Match 4', CAST(N'2022-10-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (85, N'Match 1', CAST(N'2022-10-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (86, N'Match 2', CAST(N'2022-11-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (87, N'Match 3', CAST(N'2022-11-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (88, N'Match 4', CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (89, N'Match 1', CAST(N'2022-10-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (90, N'Match 2', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (91, N'Match 3', CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (92, N'Match 4', CAST(N'2022-11-25T10:07:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (93, N'Match 1', CAST(N'2022-10-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (94, N'Match 2', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (95, N'Match 3', CAST(N'2022-10-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (96, N'Match 4', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (97, N'Match 1', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (98, N'Match 2', CAST(N'2022-11-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (99, N'Match 3', CAST(N'2022-11-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (100, N'Match 4', CAST(N'2022-10-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (101, N'Match 1', CAST(N'2022-12-03T10:15:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (102, N'Match 2', CAST(N'2022-12-03T10:13:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (103, N'Match 3', CAST(N'2022-11-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (104, N'Match 4', CAST(N'2022-11-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (105, N'Match 1', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (106, N'Match 2', CAST(N'2022-11-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (107, N'Match 3', CAST(N'2022-12-03T10:14:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (108, N'Match 4', CAST(N'2022-10-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (109, N'Match 1', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (110, N'Match 2', CAST(N'2022-11-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (111, N'Match 3', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (112, N'Match 4', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (113, N'Match 1', CAST(N'2022-10-23T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (114, N'Match 2', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (115, N'Match 3', CAST(N'2022-10-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (116, N'Match 4', NULL)
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (117, N'Match 1', CAST(N'2022-11-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (118, N'Match 2', CAST(N'2022-11-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (119, N'Match 3', CAST(N'2022-11-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Match] ([Id], [Nom], [DateFin]) VALUES (120, N'Match 4', CAST(N'2022-12-04T18:35:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Match] OFF
GO
SET IDENTITY_INSERT [dbo].[Mecanique] ON 
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (1, N'Deck building')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (2, N'Lancer de dés')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (3, N'Contrôle de territoire')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (4, N'Pose d''ouvriers')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (5, N'Bluff')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (6, N'Placement de tuiles')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (7, N'Gestion de main')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (8, N'Stop ou encore')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (9, N'Collection')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (10, N'Programmation')
GO
INSERT [dbo].[Mecanique] ([Id], [Nom]) VALUES (11, N'Draft')
GO
SET IDENTITY_INSERT [dbo].[Mecanique] OFF
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (81, 6, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (81, 11, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (81, 15, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (82, 1, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (82, 3, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (82, 8, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (83, 5, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (83, 7, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (83, 13, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (84, 2, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (84, 12, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (84, 14, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (85, 1, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (85, 2, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (85, 3, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (86, 5, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (86, 7, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (86, 15, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (87, 11, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (87, 12, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (87, 14, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (88, 6, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (88, 8, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (88, 13, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (89, 3, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (89, 5, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (89, 12, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (90, 8, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (90, 14, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (90, 15, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (91, 6, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (91, 7, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (91, 13, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (92, 1, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (92, 2, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (92, 11, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (93, 1, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (93, 2, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (93, 14, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (94, 6, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (94, 13, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (94, 15, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (95, 5, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (95, 7, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (95, 11, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (96, 3, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (96, 8, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (96, 12, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (97, 3, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (97, 8, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (97, 11, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (98, 6, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (98, 7, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (98, 13, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (99, 1, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (99, 2, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (99, 14, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (100, 5, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (100, 12, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (100, 15, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (101, 1, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (101, 6, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (101, 15, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (102, 2, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (102, 11, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (102, 12, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (103, 5, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (103, 8, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (103, 13, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (104, 3, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (104, 7, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (104, 14, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (105, 7, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (105, 13, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (105, 15, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (106, 5, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (106, 8, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (106, 14, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (107, 2, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (107, 3, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (107, 11, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (108, 1, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (108, 6, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (108, 12, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (109, 6, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (109, 11, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (109, 13, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (110, 1, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (110, 3, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (110, 7, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (111, 5, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (111, 14, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (111, 15, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (112, 2, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (112, 8, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (112, 12, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (113, 1, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (113, 5, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (113, 11, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (114, 7, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (114, 8, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (114, 14, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (115, 3, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (115, 6, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (115, 12, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (116, 2, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (116, 13, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (116, 15, 0)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (117, 1, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (117, 12, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (117, 13, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (118, 2, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (118, 7, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (118, 8, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (119, 5, 3)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (119, 6, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (119, 15, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (120, 3, 1)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (120, 11, 2)
GO
INSERT [dbo].[Score] ([MatchId], [JoueurId], [Points]) VALUES (120, 14, 3)
GO
SET IDENTITY_INSERT [dbo].[Tournoi] ON 
GO
INSERT [dbo].[Tournoi] ([Id], [Nom], [DateDebut], [DateFin]) VALUES (7, N'2022-2023', CAST(N'2022-10-03T11:13:00.000' AS DateTime), CAST(N'2022-12-18T11:14:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Tournoi] OFF
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD FOREIGN KEY([JeuId])
REFERENCES [dbo].[Jeu] ([Id])
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD  CONSTRAINT [FK__MatchTour__Match__619B8048] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Composition] CHECK CONSTRAINT [FK__MatchTour__Match__619B8048]
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD  CONSTRAINT [FK__MatchTour__Tourn__6383C8BA] FOREIGN KEY([TournoiId])
REFERENCES [dbo].[Tournoi] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Composition] CHECK CONSTRAINT [FK__MatchTour__Tourn__6383C8BA]
GO
ALTER TABLE [dbo].[Jeu]  WITH CHECK ADD FOREIGN KEY([MecaniqueId])
REFERENCES [dbo].[Mecanique] ([Id])
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD FOREIGN KEY([JoueurId])
REFERENCES [dbo].[Joueur] ([Id])
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK__Score__MatchId__534D60F1] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK__Score__MatchId__534D60F1]
GO