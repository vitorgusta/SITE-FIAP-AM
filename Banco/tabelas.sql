-- Gerado por Oracle SQL Developer Data Modeler 4.1.3.901
--   em:        2017-09-20 20:59:49 BRT
--   site:      Oracle Database 11g
--   tipo:      Oracle Database 11g




CREATE TABLE GO_AUDITORIA
  (
    ID             NUMBER NOT NULL ,
    TABELA         VARCHAR2 (30) NOT NULL ,
    TIPO_ALTERACAO VARCHAR2 (10) NOT NULL ,
    HISTORICO      VARCHAR2 (4000) ,
    DATA           DATE NOT NULL ,
    USUARIO        VARCHAR2 (300) NOT NULL
  ) ;
ALTER TABLE GO_AUDITORIA ADD CONSTRAINT GO_AUDITORIA_PK PRIMARY KEY ( ID ) ;


CREATE TABLE GO_CATEGORIA
  (
    ID        NUMBER NOT NULL ,
    CATEGORIA VARCHAR2 (200) NOT NULL ,
    STA_ATIVO VARCHAR2 (1) NOT NULL
  ) ;
ALTER TABLE GO_CATEGORIA ADD CONSTRAINT GO_CATEGORIA_PK PRIMARY KEY ( ID ) ;


CREATE TABLE GO_CONTATO
  (
    ID           NUMBER NOT NULL ,
    DT_MENSAGEM  DATE NOT NULL ,
    MENSAGEM     VARCHAR2 (2000) NOT NULL ,
    GO_PESSOA_ID NUMBER NOT NULL
  ) ;
ALTER TABLE GO_CONTATO ADD CONSTRAINT GO_CONTATO_PK PRIMARY KEY ( ID ) ;


CREATE TABLE GO_NOTICIAS
  (
    ID     NUMBER NOT NULL ,
    TITULO VARCHAR2 (200) NOT NULL ,
    MATERIA CLOB NOT NULL ,
    IMAGEM BLOB ,
    DATA_MATERIA    DATE NOT NULL ,
    STA_ATIVO       VARCHAR2 (1) NOT NULL ,
    GO_CATEGORIA_ID NUMBER NOT NULL
  ) ;
ALTER TABLE GO_NOTICIAS ADD CONSTRAINT GO_NOTICIAS_PK PRIMARY KEY ( ID ) ;


CREATE TABLE GO_PESSOA
  (
    ID              NUMBER NOT NULL ,
    NOME_COMPLETO   VARCHAR2 (200) NOT NULL ,
    ENDERECO        VARCHAR2 (200) NOT NULL ,
    EMAIL           VARCHAR2 (200 CHAR) ,
    DATA_NASCIMENTO DATE NOT NULL ,
    USUARIO         VARCHAR2 (100 CHAR) NOT NULL ,
    SENHA RAW (200) NOT NULL ,
    STA_ADM VARCHAR2 (1) NOT NULL
  ) ;
ALTER TABLE GO_PESSOA ADD CONSTRAINT GO_PESSOA_PK PRIMARY KEY ( ID ) ;


ALTER TABLE GO_CONTATO ADD CONSTRAINT GO_CONTATO_GO_PESSOA_FK FOREIGN KEY ( GO_PESSOA_ID ) REFERENCES GO_PESSOA ( ID ) ;

ALTER TABLE GO_NOTICIAS ADD CONSTRAINT GO_NOTICIAS_GO_CATEGORIA_FK FOREIGN KEY ( GO_CATEGORIA_ID ) REFERENCES GO_CATEGORIA ( ID ) ;


-- Relatório do Resumo do Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             5
-- CREATE INDEX                             0
-- ALTER TABLE                              7
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE COLLECTION TYPE                   0
-- CREATE STRUCTURED TYPE                   0
-- CREATE STRUCTURED TYPE BODY              0
-- CREATE CLUSTER                           0
-- CREATE CONTEXT                           0
-- CREATE DATABASE                          0
-- CREATE DIMENSION                         0
-- CREATE DIRECTORY                         0
-- CREATE DISK GROUP                        0
-- CREATE ROLE                              0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE SEQUENCE                          0
-- CREATE MATERIALIZED VIEW                 0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- 
-- ORDS DROP SCHEMA                         0
-- ORDS ENABLE SCHEMA                       0
-- ORDS ENABLE OBJECT                       0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
