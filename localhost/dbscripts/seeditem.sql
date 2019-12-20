\connect bsdb
CREATE TABLE item
(
 id serial PRIMARY KEY,
 name VARCHAR (255) NOT NULL,
 linkurl VARCHAR (255) NOT NULL,
 image VARCHAR (255) NOT NULL,
 parentid serial,
 click serial
);

INSERT INTO item (name, linkurl, image)
VALUES
   ('name','http://www.postgresqltutorial.com', 'image');
