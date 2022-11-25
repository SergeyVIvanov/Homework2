\c "SVI_Db1";

--
-- clients
--
INSERT INTO public.clients(
    first_name, last_name, middle_name, birthday, id_doc_kind, id_doc_serial, id_doc_number, id_doc_issue_date, phone)
    VALUES ('Бахтияров', 'Олег', 'Денисович', '1957-01-18', 21, '11 11', '222222', '2021-12-05', '+7(905)1112233');
INSERT INTO public.clients(
    first_name, last_name, middle_name, birthday, id_doc_kind, id_doc_serial, id_doc_number, id_doc_issue_date, phone)
    VALUES ('Киселёв', 'Архип', 'Тарасович', '1974-08-06', 21, '33 33', '444444', '1994-06-14', '+7(903)0401014');
INSERT INTO public.clients(
    first_name, last_name, middle_name, birthday, id_doc_kind, id_doc_serial, id_doc_number, id_doc_issue_date, phone)
    VALUES ('Макарова', 'Эмилия', 'Куприяновна', '1998-01-08', 21, '55 55', '666666', '2011-09-19', '+7(905)1488991');
INSERT INTO public.clients(
    first_name, last_name, middle_name, birthday, id_doc_kind, id_doc_serial, id_doc_number, id_doc_issue_date, phone)
    VALUES ('Мишин', 'Аполлон', 'Львович', '1984-03-27', 21, '77 77', '888888', '2020-02-04', '+7(920)9336831');
INSERT INTO public.clients(
    first_name, last_name, middle_name, birthday, id_doc_kind, id_doc_serial, id_doc_number, id_doc_issue_date, phone)
    VALUES ('Воробьёва', 'Сара', 'Лаврентьевна', '1974-06-26', 21, '99 99', '123456', '2015-02-11', '+7(909)9167971');

--
-- products
--
INSERT INTO public.products(name)
    VALUES ('Текущий счёт');
INSERT INTO public.products(name)
    VALUES ('Накопительный счёт');
INSERT INTO public.products(name)
    VALUES ('Вклад Управляй +');
INSERT INTO public.products(name)
    VALUES ('СберВклад');
INSERT INTO public.products(name)
    VALUES ('Карта Visa Gold');

--
-- client_product
--
INSERT INTO public.client_product(
    client_id, product_id, date_open, date_close, amount, currency, interest_rate)
    VALUES (1, 1, '1995-10-19', NULL, 100000, 'RUR', 0.1);
INSERT INTO public.client_product(
    client_id, product_id, date_open, date_close, amount, currency, interest_rate)
    VALUES (2, 3, '2022-03-01', NULL, 750000, 'RUR', 4.5);
INSERT INTO public.client_product(
    client_id, product_id, date_open, date_close, amount, currency, interest_rate)
    VALUES (3, 1, '2020-08-30', NULL, 0, 'RUR', 0.1);
INSERT INTO public.client_product(
    client_id, product_id, date_open, date_close, amount, currency, interest_rate)
    VALUES (3, 2, '2021-05-10', NULL, 1400000, 'RUR', 3);
INSERT INTO public.client_product(
    client_id, product_id, date_open, date_close, amount, currency, interest_rate)
    VALUES (3, 5, '2022-06-10', NULL, 73281.65, 'RUR', 0);
