\connect bsdb
CREATE TABLE folder
(
 id serial PRIMARY KEY,
 foldername VARCHAR (255) NOT NULL,
 parent serial,
 status VARCHAR (255) NOT NULL
);
ALTER TABLE "folder" OWNER TO bsuser;
Insert into folder(foldername) values('foldername');
Insert into folder(parent) values('parent');
Insert into folder(status) values('status');

INSERT INTO folder (foldername, status)
VALUES
   ('foldername','status');
