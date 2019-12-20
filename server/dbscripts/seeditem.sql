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
ALTER TABLE "item" OWNER TO bsuser;
Insert into item(name) values('name');
Insert into item(linkurl) values('linkurl');
Insert into item(image) values('image');
Insert into item(parentid) values('parentid');
Insert into item(click) values('click');

INSERT INTO item (name, linkurl, image)
VALUES
   ('name','http://www.postgresqltutorial.com', 'image');
