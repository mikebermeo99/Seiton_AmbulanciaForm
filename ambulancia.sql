CREATE TABLE public.datos_form_ambulancia
(
    no_reporte integer NOT NULL,
    nombre_entrega character varying COLLATE pg_catalog."default",
    nombre_recibe character varying COLLATE pg_catalog."default",
    coor_zonal integer,
    provincia character varying COLLATE pg_catalog."default",
    unidad_operativa character varying COLLATE pg_catalog."default",
    alfa integer,
    hora time without time zone,
    fecha date,
    combustible integer,
    temperatura integer,
    kilometraje integer,
    observacion character varying COLLATE pg_catalog."default",
    CONSTRAINT datos_form_ambulancia_pkey PRIMARY KEY (no_reporte)
)

TABLESPACE pg_default;

ALTER TABLE public.datos_form_ambulancia
    OWNER to postgres;

CREATE TABLE public.respuestas
(
    id_form integer,
    id_pregunta integer,
    valor boolean NOT NULL,
    observacion character varying COLLATE pg_catalog."default",
    CONSTRAINT fk_datos_ambulacia FOREIGN KEY (id_form)
        REFERENCES public.datos_form_ambulancia (no_reporte) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE public.respuestas
    OWNER to postgres;