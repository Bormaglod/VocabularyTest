--
-- PostgreSQL database dump
--

-- Dumped from database version 9.5.2
-- Dumped by pg_dump version 9.5.2

-- Started on 2017-01-18 15:26:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE vocabulary_test;
--
-- TOC entry 2307 (class 1262 OID 18840)
-- Name: vocabulary_test; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE vocabulary_test WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';


ALTER DATABASE vocabulary_test OWNER TO postgres;

\connect vocabulary_test

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 6 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- TOC entry 2308 (class 0 OID 0)
-- Dependencies: 6
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- TOC entry 1 (class 3079 OID 12355)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2310 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

--
-- TOC entry 217 (class 1255 OID 19245)
-- Name: add_word_type_tree_element(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION add_word_type_tree_element() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   w_l integer;
   w_c integer;
begin
   if (new.parent_id is not null) then
      select a.level, a.count_childs
         into w_l, w_c
         from word_type as a
         where a.id = new.parent_id;

      update word_type
         set count_childs = w_c + 1
         where word_type.id = new.parent_id;

      new.level = w_l + 1;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.add_word_type_tree_element() OWNER TO postgres;

--
-- TOC entry 218 (class 1255 OID 19247)
-- Name: delete_word_type_tree_element(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION delete_word_type_tree_element() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   w_c integer;
begin
   if (old.parent_id is not null) then
      select a.count_childs
         into w_c
         from word_type as a
         where a.id = old.parent_id;

      update word_type
         set count_childs = w_c - 1
         where word_type.id = old.parent_id;
   end if;

   return old;
end;$$;


ALTER FUNCTION public.delete_word_type_tree_element() OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 201 (class 1259 OID 19151)
-- Name: abbreviation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE abbreviation (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    language_id integer,
    word_type_id integer
);


ALTER TABLE abbreviation OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 19154)
-- Name: abbreviation_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE abbreviation_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE abbreviation_id_seq OWNER TO postgres;

--
-- TOC entry 2311 (class 0 OID 0)
-- Dependencies: 202
-- Name: abbreviation_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE abbreviation_id_seq OWNED BY abbreviation.id;


--
-- TOC entry 197 (class 1259 OID 19038)
-- Name: account; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE account (
    id integer NOT NULL,
    name character varying(50),
    password character varying(25),
    role smallint NOT NULL,
    CONSTRAINT chk_account_role CHECK ((role = ANY (ARRAY[0, 1])))
);


ALTER TABLE account OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 19176)
-- Name: dictionary; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE dictionary (
    id integer NOT NULL,
    left_id integer NOT NULL,
    right_id integer NOT NULL,
    dictionary_type smallint NOT NULL,
    CONSTRAINT chk_dictionary_type CHECK ((dictionary_type = ANY (ARRAY[0, 1]))),
    CONSTRAINT chk_dictionary_words CHECK ((left_id < right_id))
);


ALTER TABLE dictionary OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 19179)
-- Name: dictionary_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE dictionary_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE dictionary_id_seq OWNER TO postgres;

--
-- TOC entry 2312 (class 0 OID 0)
-- Dependencies: 204
-- Name: dictionary_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE dictionary_id_seq OWNED BY dictionary.id;


--
-- TOC entry 195 (class 1259 OID 18984)
-- Name: entry; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE entry (
    id integer NOT NULL,
    lesson_id integer NOT NULL
);


ALTER TABLE entry OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 18987)
-- Name: entry_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE entry_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE entry_id_seq OWNER TO postgres;

--
-- TOC entry 2313 (class 0 OID 0)
-- Dependencies: 196
-- Name: entry_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE entry_id_seq OWNED BY entry.id;


--
-- TOC entry 199 (class 1259 OID 19051)
-- Name: grade; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE grade (
    id integer NOT NULL,
    word_id integer,
    user_id integer,
    current smallint DEFAULT 0 NOT NULL,
    answers_count integer DEFAULT 0 NOT NULL,
    success_count integer DEFAULT 0 NOT NULL,
    error_count integer DEFAULT 0 NOT NULL,
    date_testing timestamp without time zone DEFAULT now(),
    CONSTRAINT chk_answers_count_grade CHECK ((answers_count >= 0)),
    CONSTRAINT chk_current_grade CHECK (((current >= 0) AND (current <= 7))),
    CONSTRAINT chk_error_count_grade CHECK ((error_count >= 0)),
    CONSTRAINT chk_success_count_grade CHECK ((success_count >= 0))
);


ALTER TABLE grade OWNER TO postgres;

--
-- TOC entry 2314 (class 0 OID 0)
-- Dependencies: 199
-- Name: COLUMN grade.current; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN grade.current IS 'Текущий уровень знания данного слова (0, если тестирование не проводилось, или от 1 до 7)';


--
-- TOC entry 2315 (class 0 OID 0)
-- Dependencies: 199
-- Name: COLUMN grade.answers_count; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN grade.answers_count IS 'Количество ответов';


--
-- TOC entry 2316 (class 0 OID 0)
-- Dependencies: 199
-- Name: COLUMN grade.success_count; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN grade.success_count IS 'Количество правильных ответов';


--
-- TOC entry 2317 (class 0 OID 0)
-- Dependencies: 199
-- Name: COLUMN grade.error_count; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN grade.error_count IS 'Количество ответов с ошибками';


--
-- TOC entry 2318 (class 0 OID 0)
-- Dependencies: 199
-- Name: COLUMN grade.date_testing; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN grade.date_testing IS 'Дата последнего тестирования';


--
-- TOC entry 200 (class 1259 OID 19054)
-- Name: grade_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE grade_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE grade_id_seq OWNER TO postgres;

--
-- TOC entry 2319 (class 0 OID 0)
-- Dependencies: 200
-- Name: grade_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE grade_id_seq OWNED BY grade.id;


--
-- TOC entry 187 (class 1259 OID 18882)
-- Name: language; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE language (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    alternate_name character varying(50),
    culture_locale character(3) NOT NULL,
    culture_identifier integer NOT NULL,
    image_key character varying(25),
    dictionary_locale character varying(10),
    pronunciation boolean DEFAULT false NOT NULL,
    word_type boolean DEFAULT false NOT NULL,
    synonyms boolean DEFAULT false NOT NULL,
    antonyms boolean DEFAULT false NOT NULL,
    sample boolean DEFAULT false NOT NULL,
    note boolean DEFAULT false NOT NULL,
    meaning boolean DEFAULT false NOT NULL
);


ALTER TABLE language OWNER TO postgres;

--
-- TOC entry 2320 (class 0 OID 0)
-- Dependencies: 187
-- Name: COLUMN language.name; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN language.name IS 'Наименование языка';


--
-- TOC entry 2321 (class 0 OID 0)
-- Dependencies: 187
-- Name: COLUMN language.alternate_name; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN language.alternate_name IS 'Пользовательское наименование языка';


--
-- TOC entry 2322 (class 0 OID 0)
-- Dependencies: 187
-- Name: COLUMN language.culture_locale; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN language.culture_locale IS '3-х буквенный код языка';


--
-- TOC entry 2323 (class 0 OID 0)
-- Dependencies: 187
-- Name: COLUMN language.dictionary_locale; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN language.dictionary_locale IS 'Языковой код словаря';


--
-- TOC entry 188 (class 1259 OID 18885)
-- Name: language_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE language_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE language_id_seq OWNER TO postgres;

--
-- TOC entry 2324 (class 0 OID 0)
-- Dependencies: 188
-- Name: language_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE language_id_seq OWNED BY language.id;


--
-- TOC entry 181 (class 1259 OID 18841)
-- Name: lesson; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE lesson (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    theme_id integer
);


ALTER TABLE lesson OWNER TO postgres;

--
-- TOC entry 182 (class 1259 OID 18844)
-- Name: lesson_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE lesson_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE lesson_id_seq OWNER TO postgres;

--
-- TOC entry 2325 (class 0 OID 0)
-- Dependencies: 182
-- Name: lesson_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE lesson_id_seq OWNED BY lesson.id;


--
-- TOC entry 185 (class 1259 OID 18873)
-- Name: tense; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE tense (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    language_id integer
);


ALTER TABLE tense OWNER TO postgres;

--
-- TOC entry 186 (class 1259 OID 18876)
-- Name: tense_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tense_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE tense_id_seq OWNER TO postgres;

--
-- TOC entry 2326 (class 0 OID 0)
-- Dependencies: 186
-- Name: tense_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tense_id_seq OWNED BY tense.id;


--
-- TOC entry 183 (class 1259 OID 18852)
-- Name: theme; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE theme (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    access_date timestamp without time zone DEFAULT now() NOT NULL,
    is_hidden boolean DEFAULT false NOT NULL,
    author character varying(100),
    e_mail character varying(100),
    note text,
    category character varying(50),
    license character varying(100)
);


ALTER TABLE theme OWNER TO postgres;

--
-- TOC entry 184 (class 1259 OID 18855)
-- Name: theme_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE theme_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE theme_id_seq OWNER TO postgres;

--
-- TOC entry 2327 (class 0 OID 0)
-- Dependencies: 184
-- Name: theme_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE theme_id_seq OWNED BY theme.id;


--
-- TOC entry 189 (class 1259 OID 18903)
-- Name: theme_languages; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE theme_languages (
    id integer NOT NULL,
    theme_id integer,
    language_id integer
);


ALTER TABLE theme_languages OWNER TO postgres;

--
-- TOC entry 190 (class 1259 OID 18906)
-- Name: theme_languages_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE theme_languages_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE theme_languages_id_seq OWNER TO postgres;

--
-- TOC entry 2328 (class 0 OID 0)
-- Dependencies: 190
-- Name: theme_languages_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE theme_languages_id_seq OWNED BY theme_languages.id;


--
-- TOC entry 198 (class 1259 OID 19041)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE users_id_seq OWNER TO postgres;

--
-- TOC entry 2329 (class 0 OID 0)
-- Dependencies: 198
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE users_id_seq OWNED BY account.id;


--
-- TOC entry 191 (class 1259 OID 18932)
-- Name: word; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE word (
    id integer NOT NULL,
    language_id integer NOT NULL,
    writing character varying(100),
    entry_id integer NOT NULL,
    word_type_id integer,
    pronunciation character varying(100),
    sample character varying(250),
    meaning character varying(100),
    sound_path character varying(256),
    note text
);


ALTER TABLE word OWNER TO postgres;

--
-- TOC entry 2330 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN word.writing; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word.writing IS 'Написание слова на соответствующем языке';


--
-- TOC entry 2331 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN word.word_type_id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word.word_type_id IS 'Грамматический смысл слова';


--
-- TOC entry 2332 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN word.pronunciation; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word.pronunciation IS 'Произношение слова';


--
-- TOC entry 2333 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN word.sample; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word.sample IS 'Пример использования';


--
-- TOC entry 2334 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN word.meaning; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word.meaning IS 'Значение слова';


--
-- TOC entry 2335 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN word.sound_path; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word.sound_path IS 'Путь к файлу, содержащему звуковое сопровождение для слова';


--
-- TOC entry 192 (class 1259 OID 18935)
-- Name: word_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE word_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE word_id_seq OWNER TO postgres;

--
-- TOC entry 2336 (class 0 OID 0)
-- Dependencies: 192
-- Name: word_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE word_id_seq OWNED BY word.id;


--
-- TOC entry 193 (class 1259 OID 18949)
-- Name: word_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE word_type (
    id integer NOT NULL,
    parent_id integer,
    name character varying(50) NOT NULL,
    level integer DEFAULT 1 NOT NULL,
    count_childs integer DEFAULT 0 NOT NULL,
    special smallint,
    CONSTRAINT chk_word_type_special CHECK (((special >= 0) OR (special <= 7)))
);


ALTER TABLE word_type OWNER TO postgres;

--
-- TOC entry 2337 (class 0 OID 0)
-- Dependencies: 193
-- Name: COLUMN word_type.special; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN word_type.special IS 'enum { none, noun, male, female, neutral, adjective, adverb, verb }';


--
-- TOC entry 194 (class 1259 OID 18952)
-- Name: word_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE word_type_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE word_type_id_seq OWNER TO postgres;

--
-- TOC entry 2338 (class 0 OID 0)
-- Dependencies: 194
-- Name: word_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE word_type_id_seq OWNED BY word_type.id;


--
-- TOC entry 2083 (class 2604 OID 19156)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abbreviation ALTER COLUMN id SET DEFAULT nextval('abbreviation_id_seq'::regclass);


--
-- TOC entry 2071 (class 2604 OID 19043)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY account ALTER COLUMN id SET DEFAULT nextval('users_id_seq'::regclass);


--
-- TOC entry 2084 (class 2604 OID 19181)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dictionary ALTER COLUMN id SET DEFAULT nextval('dictionary_id_seq'::regclass);


--
-- TOC entry 2070 (class 2604 OID 18989)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY entry ALTER COLUMN id SET DEFAULT nextval('entry_id_seq'::regclass);


--
-- TOC entry 2073 (class 2604 OID 19056)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY grade ALTER COLUMN id SET DEFAULT nextval('grade_id_seq'::regclass);


--
-- TOC entry 2056 (class 2604 OID 18887)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY language ALTER COLUMN id SET DEFAULT nextval('language_id_seq'::regclass);


--
-- TOC entry 2051 (class 2604 OID 18846)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY lesson ALTER COLUMN id SET DEFAULT nextval('lesson_id_seq'::regclass);


--
-- TOC entry 2055 (class 2604 OID 18878)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tense ALTER COLUMN id SET DEFAULT nextval('tense_id_seq'::regclass);


--
-- TOC entry 2052 (class 2604 OID 18857)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme ALTER COLUMN id SET DEFAULT nextval('theme_id_seq'::regclass);


--
-- TOC entry 2064 (class 2604 OID 18908)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme_languages ALTER COLUMN id SET DEFAULT nextval('theme_languages_id_seq'::regclass);


--
-- TOC entry 2065 (class 2604 OID 18937)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word ALTER COLUMN id SET DEFAULT nextval('word_id_seq'::regclass);


--
-- TOC entry 2066 (class 2604 OID 18954)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word_type ALTER COLUMN id SET DEFAULT nextval('word_type_id_seq'::regclass);


--
-- TOC entry 2299 (class 0 OID 19151)
-- Dependencies: 201
-- Data for Name: abbreviation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO abbreviation (id, name, language_id, word_type_id) VALUES (7, 'adj', 4, 3);
INSERT INTO abbreviation (id, name, language_id, word_type_id) VALUES (8, 'adj', 3, 3);
INSERT INTO abbreviation (id, name, language_id, word_type_id) VALUES (19, 'kk', 5, 2);
INSERT INTO abbreviation (id, name, language_id, word_type_id) VALUES (20, 'll', 9, 2);
INSERT INTO abbreviation (id, name, language_id, word_type_id) VALUES (21, 'uuu', 6, 2);


--
-- TOC entry 2339 (class 0 OID 0)
-- Dependencies: 202
-- Name: abbreviation_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('abbreviation_id_seq', 21, true);


--
-- TOC entry 2295 (class 0 OID 19038)
-- Dependencies: 197
-- Data for Name: account; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO account (id, name, password, role) VALUES (1, 'Administrator', NULL, 0);
INSERT INTO account (id, name, password, role) VALUES (2, 'User', NULL, 1);


--
-- TOC entry 2301 (class 0 OID 19176)
-- Dependencies: 203
-- Data for Name: dictionary; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO dictionary (id, left_id, right_id, dictionary_type) VALUES (53, 85, 87, 0);


--
-- TOC entry 2340 (class 0 OID 0)
-- Dependencies: 204
-- Name: dictionary_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('dictionary_id_seq', 53, true);


--
-- TOC entry 2293 (class 0 OID 18984)
-- Dependencies: 195
-- Data for Name: entry; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO entry (id, lesson_id) VALUES (22, 12);
INSERT INTO entry (id, lesson_id) VALUES (26, 13);
INSERT INTO entry (id, lesson_id) VALUES (30, 12);
INSERT INTO entry (id, lesson_id) VALUES (43, 13);
INSERT INTO entry (id, lesson_id) VALUES (44, 13);
INSERT INTO entry (id, lesson_id) VALUES (45, 12);
INSERT INTO entry (id, lesson_id) VALUES (46, 12);
INSERT INTO entry (id, lesson_id) VALUES (47, 12);
INSERT INTO entry (id, lesson_id) VALUES (48, 12);
INSERT INTO entry (id, lesson_id) VALUES (49, 13);
INSERT INTO entry (id, lesson_id) VALUES (50, 13);
INSERT INTO entry (id, lesson_id) VALUES (51, 13);
INSERT INTO entry (id, lesson_id) VALUES (52, 13);
INSERT INTO entry (id, lesson_id) VALUES (53, 13);
INSERT INTO entry (id, lesson_id) VALUES (54, 13);
INSERT INTO entry (id, lesson_id) VALUES (55, 12);
INSERT INTO entry (id, lesson_id) VALUES (56, 12);


--
-- TOC entry 2341 (class 0 OID 0)
-- Dependencies: 196
-- Name: entry_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('entry_id_seq', 56, true);


--
-- TOC entry 2297 (class 0 OID 19051)
-- Dependencies: 199
-- Data for Name: grade; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (3, 32, 2, 2, 0, 0, 0, '2017-01-16 11:48:22.507592');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (4, 35, 2, 2, 0, 0, 0, '2017-01-16 11:48:30.217603');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (6, 39, 2, 3, 0, 0, 0, '2017-01-16 11:48:41.977619');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (7, 60, 2, 4, 0, 0, 0, '2017-01-16 11:48:47.727627');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (8, 61, 2, 4, 0, 0, 0, '2017-01-16 11:48:52.047633');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (9, 62, 2, 5, 0, 0, 0, '2017-01-16 11:48:58.467642');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (13, 66, 2, 7, 0, 0, 0, '2017-01-16 11:49:22.707676');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (1, 24, 2, 1, 0, 0, 0, '2017-01-16 11:47:07');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (2, 28, 2, 1, 0, 0, 0, '2017-01-16 11:47:08.687491');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (5, 38, 2, 3, 0, 0, 0, '2017-01-16 11:48:35');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (10, 63, 2, 5, 0, 0, 0, '2017-01-16 11:49:03');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (14, 67, 2, 0, 0, 0, 0, '2017-01-16 11:49:30');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (11, 64, 2, 0, 0, 0, 0, '2017-01-16 11:49:10');
INSERT INTO grade (id, word_id, user_id, current, answers_count, success_count, error_count, date_testing) VALUES (12, 65, 2, 0, 0, 0, 0, '2017-01-16 11:49:15');


--
-- TOC entry 2342 (class 0 OID 0)
-- Dependencies: 200
-- Name: grade_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('grade_id_seq', 14, true);


--
-- TOC entry 2285 (class 0 OID 18882)
-- Dependencies: 187
-- Data for Name: language; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (3, 'Испанский', NULL, 'ESP', 10, NULL, NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (4, 'Немецкий', NULL, 'DEU', 7, NULL, NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (7, 'Арабский', NULL, 'ARA', 1, NULL, NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (8, 'Африкаанс', NULL, 'AFK', 54, NULL, NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (10, 'Английский', 'АНГЛ', 'ENU', 9, 'Algeria.ico', NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (17, 'Коса', NULL, 'XHO', 52, 'Antigua-Bermuda.ico', NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (6, 'Албанский', NULL, 'SQI', 28, 'Angola.ico', NULL, false, false, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (5, 'Азербайджанский', 'АЗЕР', 'AZE', 44, 'Afghanistan.ico', 'en-US', false, true, false, false, false, false, false);
INSERT INTO language (id, name, alternate_name, culture_locale, culture_identifier, image_key, dictionary_locale, pronunciation, word_type, synonyms, antonyms, sample, note, meaning) VALUES (9, 'Амхарский', 'АХМАР', 'AMH', 94, 'Albania.ico', 'ru-RU', false, true, false, false, false, false, false);


--
-- TOC entry 2343 (class 0 OID 0)
-- Dependencies: 188
-- Name: language_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('language_id_seq', 17, true);


--
-- TOC entry 2279 (class 0 OID 18841)
-- Dependencies: 181
-- Data for Name: lesson; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO lesson (id, name, theme_id) VALUES (12, 'Lesson 1', 9);
INSERT INTO lesson (id, name, theme_id) VALUES (13, 'Lesson 2', 9);
INSERT INTO lesson (id, name, theme_id) VALUES (15, 'Lesson 3', 9);
INSERT INTO lesson (id, name, theme_id) VALUES (16, 'Lesson 4', 9);


--
-- TOC entry 2344 (class 0 OID 0)
-- Dependencies: 182
-- Name: lesson_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('lesson_id_seq', 16, true);


--
-- TOC entry 2283 (class 0 OID 18873)
-- Dependencies: 185
-- Data for Name: tense; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO tense (id, name, language_id) VALUES (1, 'tense1', 5);
INSERT INTO tense (id, name, language_id) VALUES (2, 'tense2', 5);
INSERT INTO tense (id, name, language_id) VALUES (4, 'tense1', 9);
INSERT INTO tense (id, name, language_id) VALUES (5, 'LOL', 9);
INSERT INTO tense (id, name, language_id) VALUES (3, 'tense31', 5);
INSERT INTO tense (id, name, language_id) VALUES (6, 'tense41', 5);
INSERT INTO tense (id, name, language_id) VALUES (8, 'sss1', 6);
INSERT INTO tense (id, name, language_id) VALUES (9, 'sss2', 6);


--
-- TOC entry 2345 (class 0 OID 0)
-- Dependencies: 186
-- Name: tense_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('tense_id_seq', 9, true);


--
-- TOC entry 2281 (class 0 OID 18852)
-- Dependencies: 183
-- Data for Name: theme; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO theme (id, name, access_date, is_hidden, author, e_mail, note, category, license) VALUES (9, 'Без имени3', '2017-01-18 13:26:31', false, 'Сергей', NULL, NULL, NULL, NULL);
INSERT INTO theme (id, name, access_date, is_hidden, author, e_mail, note, category, license) VALUES (8, 'Без имени2', '2016-12-30 09:46:34', false, 'Сергей', NULL, NULL, NULL, NULL);


--
-- TOC entry 2346 (class 0 OID 0)
-- Dependencies: 184
-- Name: theme_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('theme_id_seq', 9, true);


--
-- TOC entry 2287 (class 0 OID 18903)
-- Dependencies: 189
-- Data for Name: theme_languages; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO theme_languages (id, theme_id, language_id) VALUES (27, 9, 5);
INSERT INTO theme_languages (id, theme_id, language_id) VALUES (28, 9, 9);
INSERT INTO theme_languages (id, theme_id, language_id) VALUES (29, 9, 17);
INSERT INTO theme_languages (id, theme_id, language_id) VALUES (30, 9, 6);
INSERT INTO theme_languages (id, theme_id, language_id) VALUES (31, 8, 5);
INSERT INTO theme_languages (id, theme_id, language_id) VALUES (32, 8, 6);
INSERT INTO theme_languages (id, theme_id, language_id) VALUES (33, 8, 9);


--
-- TOC entry 2347 (class 0 OID 0)
-- Dependencies: 190
-- Name: theme_languages_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('theme_languages_id_seq', 33, true);


--
-- TOC entry 2348 (class 0 OID 0)
-- Dependencies: 198
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('users_id_seq', 2, true);


--
-- TOC entry 2289 (class 0 OID 18932)
-- Dependencies: 191
-- Data for Name: word; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (35, 9, 'ллла', 26, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (32, 5, 'kkkkk', 26, 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (24, 5, 'dog', 22, 2, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (28, 9, 'собака', 22, 2, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (60, 5, 'ffd', 43, 4, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (61, 9, 'ffg', 43, 4, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (69, 5, 'as', 47, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (70, 9, 'sa', 47, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (71, 5, 'ds', 48, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (72, 9, 'fd', 48, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (85, 5, 'd3', 55, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (86, 9, 'd4', 55, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (87, 5, 'd43', 56, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (88, 9, 'd432', 56, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (73, 5, 'sad', 49, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (74, 9, 'dsa', 49, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (75, 5, 'dsd', 50, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (76, 9, 'ffff', 50, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (77, 5, 'pppp', 51, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (78, 9, 'ppooo', 51, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (79, 5, 'ptpt', 52, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (80, 9, 'hfhf', 52, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (81, 5, 'hfg', 53, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (82, 9, 'hdf', 53, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (83, 5, 'ye', 54, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (84, 9, 'fh', 54, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (39, 9, 'gfd', 30, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (38, 5, 'dfsf2', 30, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (63, 9, 'свинья1', 44, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (62, 5, 'pig', 44, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (68, 9, 'sss', 46, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (67, 5, 'aaa21', 46, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (66, 17, 'ggg', 45, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (65, 9, 'fff2', 45, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO word (id, language_id, writing, entry_id, word_type_id, pronunciation, sample, meaning, sound_path, note) VALUES (64, 5, 'ddd22', 45, NULL, NULL, NULL, NULL, NULL, NULL);


--
-- TOC entry 2349 (class 0 OID 0)
-- Dependencies: 192
-- Name: word_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('word_id_seq', 88, true);


--
-- TOC entry 2291 (class 0 OID 18949)
-- Dependencies: 193
-- Data for Name: word_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO word_type (id, parent_id, name, level, count_childs, special) VALUES (2, NULL, 'Глагол', 1, 0, NULL);
INSERT INTO word_type (id, parent_id, name, level, count_childs, special) VALUES (3, NULL, 'Прилагательное', 1, 0, NULL);
INSERT INTO word_type (id, parent_id, name, level, count_childs, special) VALUES (4, NULL, 'Наречие', 1, 0, NULL);
INSERT INTO word_type (id, parent_id, name, level, count_childs, special) VALUES (1, NULL, 'Существительное', 1, 0, NULL);


--
-- TOC entry 2350 (class 0 OID 0)
-- Dependencies: 194
-- Name: word_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('word_type_id_seq', 26, true);


--
-- TOC entry 2139 (class 2606 OID 19161)
-- Name: pk_id_abbreviation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abbreviation
    ADD CONSTRAINT pk_id_abbreviation PRIMARY KEY (id);


--
-- TOC entry 2145 (class 2606 OID 19186)
-- Name: pk_id_dictionary; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dictionary
    ADD CONSTRAINT pk_id_dictionary PRIMARY KEY (id);


--
-- TOC entry 2125 (class 2606 OID 18994)
-- Name: pk_id_entry; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY entry
    ADD CONSTRAINT pk_id_entry PRIMARY KEY (id);


--
-- TOC entry 2133 (class 2606 OID 19061)
-- Name: pk_id_grade; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY grade
    ADD CONSTRAINT pk_id_grade PRIMARY KEY (id);


--
-- TOC entry 2102 (class 2606 OID 18892)
-- Name: pk_id_language; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY language
    ADD CONSTRAINT pk_id_language PRIMARY KEY (id);


--
-- TOC entry 2089 (class 2606 OID 18851)
-- Name: pk_id_lesson; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY lesson
    ADD CONSTRAINT pk_id_lesson PRIMARY KEY (id);


--
-- TOC entry 2098 (class 2606 OID 18894)
-- Name: pk_id_tense; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tense
    ADD CONSTRAINT pk_id_tense PRIMARY KEY (id);


--
-- TOC entry 2093 (class 2606 OID 18862)
-- Name: pk_id_theme; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme
    ADD CONSTRAINT pk_id_theme PRIMARY KEY (id);


--
-- TOC entry 2110 (class 2606 OID 18913)
-- Name: pk_id_theme_languages; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme_languages
    ADD CONSTRAINT pk_id_theme_languages PRIMARY KEY (id);


--
-- TOC entry 2127 (class 2606 OID 19048)
-- Name: pk_id_users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY account
    ADD CONSTRAINT pk_id_users PRIMARY KEY (id);


--
-- TOC entry 2117 (class 2606 OID 18942)
-- Name: pk_id_word; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word
    ADD CONSTRAINT pk_id_word PRIMARY KEY (id);


--
-- TOC entry 2120 (class 2606 OID 18959)
-- Name: pk_id_word_type; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word_type
    ADD CONSTRAINT pk_id_word_type PRIMARY KEY (id);


--
-- TOC entry 2104 (class 2606 OID 18931)
-- Name: unq_culture_language; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY language
    ADD CONSTRAINT unq_culture_language UNIQUE (culture_locale, culture_identifier);


--
-- TOC entry 2112 (class 2606 OID 18927)
-- Name: unq_language_theme_languages; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme_languages
    ADD CONSTRAINT unq_language_theme_languages UNIQUE (theme_id, language_id);


--
-- TOC entry 2106 (class 2606 OID 18929)
-- Name: unq_name_language; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY language
    ADD CONSTRAINT unq_name_language UNIQUE (name);


--
-- TOC entry 2091 (class 2606 OID 18872)
-- Name: unq_name_lesson; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY lesson
    ADD CONSTRAINT unq_name_lesson UNIQUE (theme_id, name);


--
-- TOC entry 2100 (class 2606 OID 18902)
-- Name: unq_name_tense; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tense
    ADD CONSTRAINT unq_name_tense UNIQUE (language_id, name);


--
-- TOC entry 2095 (class 2606 OID 18864)
-- Name: unq_name_theme; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme
    ADD CONSTRAINT unq_name_theme UNIQUE (name);


--
-- TOC entry 2129 (class 2606 OID 19050)
-- Name: unq_name_users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY account
    ADD CONSTRAINT unq_name_users UNIQUE (name);


--
-- TOC entry 2122 (class 2606 OID 19008)
-- Name: unq_name_word_type; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word_type
    ADD CONSTRAINT unq_name_word_type UNIQUE (name);


--
-- TOC entry 2135 (class 2606 OID 19253)
-- Name: unq_word_grade; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY grade
    ADD CONSTRAINT unq_word_grade UNIQUE (word_id, user_id);


--
-- TOC entry 2141 (class 2606 OID 19175)
-- Name: unq_word_type_abbreviation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abbreviation
    ADD CONSTRAINT unq_word_type_abbreviation UNIQUE (word_type_id, language_id);


--
-- TOC entry 2147 (class 2606 OID 19201)
-- Name: unq_words_dictionary; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dictionary
    ADD CONSTRAINT unq_words_dictionary UNIQUE (left_id, right_id);


--
-- TOC entry 2113 (class 1259 OID 19017)
-- Name: fki_entry_word; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_entry_word ON word USING btree (entry_id);


--
-- TOC entry 2136 (class 1259 OID 19167)
-- Name: fki_language_abbreviation; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_language_abbreviation ON abbreviation USING btree (language_id);


--
-- TOC entry 2096 (class 1259 OID 18900)
-- Name: fki_language_tense; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_language_tense ON tense USING btree (language_id);


--
-- TOC entry 2107 (class 1259 OID 18925)
-- Name: fki_language_theme_languages; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_language_theme_languages ON theme_languages USING btree (language_id);


--
-- TOC entry 2114 (class 1259 OID 18948)
-- Name: fki_language_word; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_language_word ON word USING btree (language_id);


--
-- TOC entry 2123 (class 1259 OID 19000)
-- Name: fki_lesson_entry; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_lesson_entry ON entry USING btree (lesson_id);


--
-- TOC entry 2118 (class 1259 OID 19006)
-- Name: fki_parent_word_type; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_parent_word_type ON word_type USING btree (parent_id);


--
-- TOC entry 2087 (class 1259 OID 18870)
-- Name: fki_theme_lesson; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_theme_lesson ON lesson USING btree (theme_id);


--
-- TOC entry 2108 (class 1259 OID 18919)
-- Name: fki_theme_theme_languages; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_theme_theme_languages ON theme_languages USING btree (theme_id);


--
-- TOC entry 2130 (class 1259 OID 19073)
-- Name: fki_user_grade; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_user_grade ON grade USING btree (user_id);


--
-- TOC entry 2131 (class 1259 OID 19067)
-- Name: fki_word_grade; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_word_grade ON grade USING btree (word_id);


--
-- TOC entry 2142 (class 1259 OID 19192)
-- Name: fki_word_left_dictionary; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_word_left_dictionary ON dictionary USING btree (left_id);


--
-- TOC entry 2143 (class 1259 OID 19198)
-- Name: fki_word_right_dictionary; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_word_right_dictionary ON dictionary USING btree (right_id);


--
-- TOC entry 2137 (class 1259 OID 19173)
-- Name: fki_word_type_abbreviation; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_word_type_abbreviation ON abbreviation USING btree (word_type_id);


--
-- TOC entry 2115 (class 1259 OID 19028)
-- Name: fki_word_type_word; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_word_type_word ON word USING btree (word_type_id);


--
-- TOC entry 2164 (class 2620 OID 19248)
-- Name: word_type_bd0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER word_type_bd0 BEFORE DELETE ON word_type FOR EACH ROW EXECUTE PROCEDURE delete_word_type_tree_element();


--
-- TOC entry 2163 (class 2620 OID 19246)
-- Name: word_type_bi0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER word_type_bi0 BEFORE INSERT ON word_type FOR EACH ROW EXECUTE PROCEDURE add_word_type_tree_element();


--
-- TOC entry 2153 (class 2606 OID 19012)
-- Name: fk_entry_word; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word
    ADD CONSTRAINT fk_entry_word FOREIGN KEY (entry_id) REFERENCES entry(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2159 (class 2606 OID 19162)
-- Name: fk_language_abbreviation; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abbreviation
    ADD CONSTRAINT fk_language_abbreviation FOREIGN KEY (language_id) REFERENCES language(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2149 (class 2606 OID 18895)
-- Name: fk_language_tense; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tense
    ADD CONSTRAINT fk_language_tense FOREIGN KEY (language_id) REFERENCES language(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2151 (class 2606 OID 18920)
-- Name: fk_language_theme_languages; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme_languages
    ADD CONSTRAINT fk_language_theme_languages FOREIGN KEY (language_id) REFERENCES language(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2152 (class 2606 OID 18943)
-- Name: fk_language_word; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word
    ADD CONSTRAINT fk_language_word FOREIGN KEY (language_id) REFERENCES language(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2156 (class 2606 OID 18995)
-- Name: fk_lesson_entry; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY entry
    ADD CONSTRAINT fk_lesson_entry FOREIGN KEY (lesson_id) REFERENCES lesson(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2155 (class 2606 OID 19001)
-- Name: fk_parent_word_type; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word_type
    ADD CONSTRAINT fk_parent_word_type FOREIGN KEY (parent_id) REFERENCES word_type(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2148 (class 2606 OID 18865)
-- Name: fk_theme_lesson; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY lesson
    ADD CONSTRAINT fk_theme_lesson FOREIGN KEY (theme_id) REFERENCES theme(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2150 (class 2606 OID 18914)
-- Name: fk_theme_theme_languages; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY theme_languages
    ADD CONSTRAINT fk_theme_theme_languages FOREIGN KEY (theme_id) REFERENCES theme(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2158 (class 2606 OID 19068)
-- Name: fk_user_grade; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY grade
    ADD CONSTRAINT fk_user_grade FOREIGN KEY (user_id) REFERENCES account(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2157 (class 2606 OID 19062)
-- Name: fk_word_grade; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY grade
    ADD CONSTRAINT fk_word_grade FOREIGN KEY (word_id) REFERENCES word(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2161 (class 2606 OID 19187)
-- Name: fk_word_left_dictionary; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dictionary
    ADD CONSTRAINT fk_word_left_dictionary FOREIGN KEY (left_id) REFERENCES word(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2162 (class 2606 OID 19193)
-- Name: fk_word_right_dictionary; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dictionary
    ADD CONSTRAINT fk_word_right_dictionary FOREIGN KEY (right_id) REFERENCES word(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2160 (class 2606 OID 19168)
-- Name: fk_word_type_abbreviation; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abbreviation
    ADD CONSTRAINT fk_word_type_abbreviation FOREIGN KEY (word_type_id) REFERENCES word_type(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2154 (class 2606 OID 19023)
-- Name: fk_word_type_word; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY word
    ADD CONSTRAINT fk_word_type_word FOREIGN KEY (word_type_id) REFERENCES word_type(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2309 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2017-01-18 15:26:27

--
-- PostgreSQL database dump complete
--

