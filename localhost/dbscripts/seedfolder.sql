\connect bsdb
CREATE TABLE folder
(
 id serial PRIMARY KEY,
 foldername VARCHAR (255) NOT NULL,
 parent serial,
 status VARCHAR (255) NOT NULL
);

INSERT INTO folder (foldername, status)
VALUES
   ('foldername','status');
