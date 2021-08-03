

/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: AUTEUR
------------------------------------------------------------*/
CREATE TABLE AUTEUR(
	id_auteur       INT IDENTITY (1,1) NOT NULL ,
	nom_auteur      VARCHAR (50) NOT NULL ,
	prenom_auteur   VARCHAR (50) NOT NULL  ,
	CONSTRAINT AUTEUR_PK PRIMARY KEY (id_auteur)
);


/*------------------------------------------------------------
-- Table: EDITEUR
------------------------------------------------------------*/
CREATE TABLE EDITEUR(
	id_editeur    INT IDENTITY (1,1) NOT NULL ,
	nom_editeur   VARCHAR (50) NOT NULL  ,
	CONSTRAINT EDITEUR_PK PRIMARY KEY (id_editeur)
);


/*------------------------------------------------------------
-- Table: courant_litteraire
------------------------------------------------------------*/
CREATE TABLE courant_litteraire(
	id_courant_lit            INT IDENTITY (1,1) NOT NULL ,
	libelle_courant_lit       VARCHAR (50) NOT NULL ,
	description_courant_lit   TEXT  NOT NULL  ,
	CONSTRAINT courant_litteraire_PK PRIMARY KEY (id_courant_lit)
);


/*------------------------------------------------------------
-- Table: genre
------------------------------------------------------------*/
CREATE TABLE genre(
	id_genre         INT IDENTITY (1,1) NOT NULL ,
	libelle_genre    VARCHAR (50) NOT NULL ,
	id_courant_lit   INT  NOT NULL  ,
	CONSTRAINT genre_PK PRIMARY KEY (id_genre)

	,CONSTRAINT genre_courant_litteraire_FK FOREIGN KEY (id_courant_lit) REFERENCES courant_litteraire(id_courant_lit)
);


/*------------------------------------------------------------
-- Table: livre
------------------------------------------------------------*/
CREATE TABLE livre(
	id_livre    INT IDENTITY (1,1) NOT NULL ,
	nom_livre   VARCHAR (50) NOT NULL ,
	id_genre    INT  NOT NULL ,
	id_auteur   INT  NOT NULL  ,
	CONSTRAINT livre_PK PRIMARY KEY (id_livre)

	,CONSTRAINT livre_genre_FK FOREIGN KEY (id_genre) REFERENCES genre(id_genre)
	,CONSTRAINT livre_AUTEUR0_FK FOREIGN KEY (id_auteur) REFERENCES AUTEUR(id_auteur)
);


/*------------------------------------------------------------
-- Table: EDITE
------------------------------------------------------------*/
CREATE TABLE EDITE(
	id_livre       INT  NOT NULL ,
	id_editeur     INT  NOT NULL ,
	isbn           VARCHAR (50) NOT NULL ,
	date_edition   DATETIME NOT NULL  ,
	CONSTRAINT EDITE_PK PRIMARY KEY (id_livre,id_editeur)

	,CONSTRAINT EDITE_livre_FK FOREIGN KEY (id_livre) REFERENCES livre(id_livre)
	,CONSTRAINT EDITE_EDITEUR0_FK FOREIGN KEY (id_editeur) REFERENCES EDITEUR(id_editeur)
);



