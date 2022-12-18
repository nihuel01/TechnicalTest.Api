INSERT INTO trol VALUES ( 'Administrador',-1)
INSERT INTO trol VALUES ( 'Cliente', -1)
GO

INSERT INTO tUsers(Id, cod_usuario, txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, cod_rol, sn_activo, LockoutEnabled, AccessFailedCount, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled)  
VALUES (NEWID() ,1,'Admin', 'PassAdmin123', 'Administrador', 'Test', '1234321', -1,-1, 0, 0, 0, 0, 0)
INSERT INTO tUsers(Id, cod_usuario, txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, cod_rol, sn_activo, LockoutEnabled, AccessFailedCount, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled) 
VALUES (NEWID(),2, 'userTest', 'Test1', 'Ariel', 'ApellidoConA', '12312321', 1, -1, 0, 0, 0, 0, 0)
INSERT INTO tUsers(Id, cod_usuario, txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, cod_rol, sn_activo, LockoutEnabled, AccessFailedCount, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled) 
VALUES (NEWID(), 3, 'userTest2', 'Test2', 'Bernardo', 'ApellidoConB', '12312322', 1, -1, 0, 0, 0, 0, 0)
INSERT INTO tUsers(Id, cod_usuario, txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, cod_rol, sn_activo, LockoutEnabled, AccessFailedCount, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled) 
VALUES (NEWID(), 4, 'userTest3', 'Test3', 'Carlos', 'ApellidoConC', '12312323', 1, -1, 0, 0, 0, 0, 0)

GO
INSERT INTO tPelicula VALUES ('Duro de matar III', 3, 0,1.5,5.0)
INSERT INTO tPelicula VALUES ('Todo Poderoso', 2,1,1.5,7.0)
INSERT INTO tPelicula VALUES ('Stranger than fiction', 1,1,1.5,8.0)
INSERT INTO tPelicula VALUES ('OUIJA', 0,2,2.0,20.50)GOINSERT INTO tGenero VALUES('Acción')
INSERT INTO tGenero VALUES('Comedia')
INSERT INTO tGenero VALUES('Drama')
INSERT INTO tGenero VALUES('Terror')
GO

INSERT INTO tGeneroPelicula VALUES(1,1)
INSERT INTO tGeneroPelicula VALUES(2,2)
INSERT INTO tGeneroPelicula VALUES(3,2)
INSERT INTO tGeneroPelicula VALUES(3,3)
INSERT INTO tGeneroPelicula VALUES(4,4)

