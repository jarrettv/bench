
CREATE TABLE `db`.`genders` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(5) NOT NULL,
  `name` VARCHAR(20) NOT NULL,
  `order` INT NOT NULL,
  PRIMARY KEY (`id`));


INSERT INTO `db`.`genders`(`code`,`name`,`order`) VALUES ('U','Unknown',0);
INSERT INTO `db`.`genders`(`code`,`name`,`order`) VALUES ('M','Male',100);
INSERT INTO `db`.`genders`(`code`,`name`,`order`) VALUES ('F','Female',100);
INSERT INTO `db`.`genders`(`code`,`name`,`order`) VALUES ('T','Trans',200);