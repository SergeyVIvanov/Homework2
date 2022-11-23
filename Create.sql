DROP DATABASE IF EXISTS "SVI_Db1" (FORCE);
CREATE DATABASE "SVI_Db1";
\c "SVI_Db1";

--
-- clients
--
CREATE SEQUENCE clients_id_seq;

CREATE TABLE clients
(
    id                BIGINT        NOT NULL  DEFAULT NEXTVAL('clients_id_seq'),
    first_name        VARCHAR(255)  NOT NULL,
    last_name         VARCHAR(255)  NOT NULL,
    middle_name       VARCHAR(255),
    birthday          DATE          NOT NULL,
    id_doc_kind       SMALLINT      NOT NULL,
    id_doc_serial     VARCHAR(10),
    id_doc_number     VARCHAR(10)   NOT NULL,
    id_doc_issue_date DATE          NOT NULL,
    phone             VARCHAR(20)   NOT NULL,
  
    CONSTRAINT clients_pk PRIMARY KEY (id)
);

--
-- products
--
CREATE SEQUENCE products_id_seq;

CREATE TABLE products
(
    id   BIGINT       NOT NULL  DEFAULT NEXTVAL('products_id_seq'),
    name VARCHAR(255) NOT NULL,
  
    CONSTRAINT products_pk PRIMARY KEY (id)
);

--
-- client_product
--
CREATE TABLE client_product
(
    client_id     BIGINT  NOT NULL,
    product_id    BIGINT  NOT NULL,
    date_open     DATE    NOT NULL,
    date_close    DATE,
    amount        MONEY   NOT NULL,
    currency      CHAR(3) NOT NULL,
    interest_rate MONEY   NOT NULL,
  
    CONSTRAINT client_product_pk PRIMARY KEY (client_id, product_id),
    CONSTRAINT client_product_fk_clients_id FOREIGN KEY (client_id) REFERENCES clients(id) ON DELETE CASCADE,
    CONSTRAINT client_product_fk_products_id FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE
);
