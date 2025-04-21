parser grammar BigQueryParser;

options {
  tokenVocab=BigQueryLexer;
}

statements
 : ';'* statement ( ';'+ statement )* ';'* EOF
 ;

single_statement
 : ';'* statement ';'* EOF
 ;

statement
 : query_statement
 | create_table
 | create_table_like
 | create_table_copy
 | create_snapshot_table
 | create_table_clone
 | create_view
 | create_schema
 | create_materialized_view
 | create_materialized_view_as_replica
 | create_external_schema
 | create_external_table
 | create_function
 | create_js_function
 | create_py_function
 | create_remote_function
 | create_aggregate_function
 | create_aggregate_js_function
 | create_table_function
 | create_procedure
 | create_stored_procedure
 | create_row_access_policy
 | create_capacity
 | create_reservation
 | create_assignment
 | create_search_index
 | create_vector_index
 | alter_schema_set_default_collate
 | alter_schema_set_options
 | alter_schema_add_replica
 | alter_schema_drop_replica
 | alter_table_set_options
 | alter_table_add_column
 | alter_table_add_foreign_key
 | alter_table_add_primary_key
 | alter_table_rename
 | alter_table_rename_column
 | alter_table_drop_column
 | alter_table_drop_constraint
 | alter_table_drop_primary_key
 | alter_table_set_default_collate
 | alter_table_column_set_options
 | alter_table_column_drop_not_null
 | alter_table_column_set_data_type
 | alter_table_column_set_default
 | alter_table_column_drop_default
 | alter_view
 | alter_materialized_view
 | alter_organication
 | alter_project
 | alter_bi_capacity
 | alter_capacity
 | alter_reservation
 | undrop_schema
 | drop_schema
 | drop_table
 | drop_snapshot_table
 | drop_external_table
 | drop_view
 | drop_materialized_view
 | drop_function
 | drop_table_function
 | drop_procedure
 | drop_row_access_policy
 | drop_capacity
 | drop_reservation
 | drop_assignment
 | drop_search_index
 | drop_vector_index
 | set
 ;

query_statement
 : query_expression
 ;

// CREATE [ OR REPLACE ] [ TEMP | TEMPORARY ] TABLE [ IF NOT EXISTS ]
// table_name
// [(
//   column | constraint_definition[, ...]
// )]
// [DEFAULT COLLATE collate_specification]
// [PARTITION BY partition_expression]
// [CLUSTER BY clustering_column_list]
// [WITH CONNECTION connection_name]
// [OPTIONS(table_option_list)]
// [AS query_statement]
create_table
 : CREATE ( OR REPLACE )? ( TEMP | TEMPORARY )? TABLE ( IF NOT EXISTS )?
   table_name=path_expression ( '(' column_constraint_definitions ')' )?
   ( DEFAULT COLLATE collate_specification=string_literal )?
   ( PARTITION BY expression )?
   ( CLUSTER BY path_expressions )?
   ( WITH CONNECTION connection_name=identifier )?
   ( OPTIONS '(' option_parameters ')' )?
   ( AS query_statement )?
 ;

// CREATE [ OR REPLACE ] TABLE [ IF NOT EXISTS ]
// table_name
// LIKE [[project_name.]dataset_name.]source_table_name
// ...
// [OPTIONS(table_option_list)]
create_table_like
 : CREATE ( OR REPLACE )? TABLE ( IF NOT EXISTS )?
   table_name=path_expression
   LIKE ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? source_table_name=identifier
   ( DEFAULT COLLATE collate_specification=string_literal )?
   ( PARTITION BY expression )?
   ( CLUSTER BY path_expressions )?
   ( WITH CONNECTION connection_name=identifier )?
   ( OPTIONS '(' option_parameters ')' )?
   ( AS query_statement )?
 ;

// CREATE [ OR REPLACE ] TABLE [ IF NOT EXISTS ]
// table_name
// COPY source_table_name
// ...
// [OPTIONS(table_option_list)]
create_table_copy
 : CREATE ( OR REPLACE )? TABLE ( IF NOT EXISTS )?
   table_name=path_expression
   COPY source_table_name=path_expression
   ( DEFAULT COLLATE collate_specification=string_literal )?
   ( PARTITION BY expression )?
   ( CLUSTER BY path_expressions )?
   ( WITH CONNECTION connection_name=identifier )?
   ( OPTIONS '(' option_parameters ')' )?
   ( AS query_statement )?
 ;

// CREATE SNAPSHOT TABLE [ IF NOT EXISTS ] table_snapshot_name
// CLONE source_table_name
// [FOR SYSTEM_TIME AS OF time_expression]
// [OPTIONS(snapshot_option_list)]
create_snapshot_table
 : CREATE SNAPSHOT TABLE ( IF NOT EXISTS )? table_snapshot_name=path_expression
   CLONE source_table_name=path_expression
   ( FOR SYSTEM_TIME AS OF expression )?
   ( OPTIONS '(' option_parameters ')' )?
 ;

// CREATE TABLE [ IF NOT EXISTS ]
// destination_table_name
// CLONE source_table_name [FOR SYSTEM_TIME AS OF time_expression]
// ...
// [OPTIONS(table_option_list)]
create_table_clone
 : CREATE TABLE ( IF NOT EXISTS )?
   destination_table_name=path_expression
   CLONE source_table_name=path_expression ( FOR SYSTEM_TIME AS OF expression )?
   ( DEFAULT COLLATE collate_specification=string_literal )?
   ( PARTITION BY expression )?
   ( CLUSTER BY path_expressions )?
   ( WITH CONNECTION connection_name=identifier )?
   ( OPTIONS '(' option_parameters ')' )?
   ( AS query_statement )?
 ;

// CREATE [ OR REPLACE ] VIEW [ IF NOT EXISTS ] view_name
// [(view_column_name_list)]
// [OPTIONS(view_option_list)]
// AS query_expression
create_view
 : CREATE ( OR REPLACE )? VIEW ( IF NOT EXISTS )? view_name=path_expression
   ( '(' view_column_name_list ')' )?
   ( OPTIONS '(' option_parameters ')' )?
   AS query_expression
 ;

// CREATE [ OR REPLACE ] MATERIALIZED VIEW [ IF NOT EXISTS ] materialized_view_name
// [PARTITION BY partition_expression]
// [CLUSTER BY clustering_column_list]
// [OPTIONS(materialized_view_option_list)]
// AS query_expression
create_materialized_view
 : CREATE ( OR REPLACE )? MATERIALIZED VIEW ( IF NOT EXISTS )? materialized_view_name=path_expression
   ( PARTITION BY expression )?
   ( CLUSTER BY clustering_column_list=path_expressions )?
   ( OPTIONS '(' option_parameters ')' )?
   AS query_expression
 ;

// CREATE MATERIALIZED VIEW replica_name
// [OPTIONS(materialized_view_replica_option_list)]
// AS REPLICA OF source_materialized_view_name
create_materialized_view_as_replica
 : CREATE MATERIALIZED VIEW replica_name=path_expression
   ( OPTIONS '(' option_parameters ')' )?
   AS REPLICA OF source_materialized_view_name=path_expression
 ;

// CREATE EXTERNAL SCHEMA [ IF NOT EXISTS ] dataset_name
// [WITH CONNECTION connection_name]
// [OPTIONS(external_schema_option_list)]
create_external_schema
 : CREATE EXTERNAL SCHEMA ( IF NOT EXISTS )? dataset_name=path_expression
   ( WITH CONNECTION connection_namepath_expression=path_expression )?
   ( OPTIONS '(' option_parameters ')' )?
 ;

// CREATE [ OR REPLACE ] EXTERNAL TABLE [ IF NOT EXISTS ] table_name
// [(
//   column_name column_schema,
//   ...
// )]
// [WITH CONNECTION {connection_name | DEFAULT}]
// [WITH PARTITION COLUMNS
//   [(
//       partition_column_name partition_column_type,
//       ...
//   )]
// ]
// OPTIONS (
//   external_table_option_list,
//   ...
// )
create_external_table
 : CREATE ( OR REPLACE )? EXTERNAL TABLE ( IF NOT EXISTS )? table_name=path_expression
   ( '(' column_names=column_name_schemas ')' )?
   ( WITH CONNECTION ( connection_name=identifier | DEFAULT ) )?
   ( WITH PARTITION COLUMNS ( '(' partition_columns=column_name_schemas ')' )? )?
   OPTIONS '(' option_parameters ')'
 ;

column_name_schemas
 : column_name_schema ( ',' column_name_schema )*
 ;

column_name_schema
 : column_name=identifier data_type
 ;

// CREATE [ OR REPLACE ] [ TEMPORARY | TEMP ] FUNCTION [ IF NOT EXISTS ]
//     [[project_name.]dataset_name.]function_name
//     ([named_parameter[, ...]])
//   [RETURNS data_type]
//   AS (sql_expression)
//   [OPTIONS (function_option_list)]
create_function
 : CREATE ( OR REPLACE )? ( TEMPORARY | TEMP )? FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier
   '(' named_parameters? ')'
   ( RETURNS data_type )?
   AS '(' expression ')'
   ( OPTIONS '(' option_parameters ')' )?
 ;

named_parameters
 : named_parameter ( ',' named_parameter )*
 ;

// named_parameter:
//   param_name param_type
named_parameter
 : param_name=identifier param_type=data_type
 ;

// CREATE [OR REPLACE] [TEMPORARY | TEMP] FUNCTION [IF NOT EXISTS]
//     [[project_name.]dataset_name.]function_name
//     ([named_parameter[, ...]])
//   RETURNS data_type
//   [determinism_specifier]
//   LANGUAGE js
//   [OPTIONS (function_option_list)]
//   AS javascript_code
//
// determinism_specifier:
//   { DETERMINISTIC | NOT DETERMINISTIC }
create_js_function
 : CREATE ( OR REPLACE )? ( TEMPORARY | TEMP )? FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier
   '(' named_parameters? ')'
   RETURNS data_type
   ( DETERMINISTIC | NOT DETERMINISTIC )?
   LANGUAGE identifier
   ( OPTIONS '(' option_parameters ')' )?
   AS javascript_code=string_literal
 ;

// CREATE [OR REPLACE] FUNCTION [IF NOT EXISTS]
//     [project_name.]dataset_name.function_name
//     ([named_parameter[, ...]])
//   RETURNS data_type
//   LANGUAGE python
//   [WITH CONNECTION connection_path]
//   OPTIONS (function_option_list)
//   AS python_code
create_py_function
 : CREATE ( OR REPLACE )? ( TEMPORARY | TEMP )? FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier
   '(' named_parameters? ')'
   RETURNS data_type
   LANGUAGE identifier
   ( WITH CONNECTION connection_path=path_expression )?
   OPTIONS '(' option_parameters ')'
   AS python_code=string_literal
 ;

// CREATE [OR REPLACE] [TEMPORARY | TEMP] FUNCTION [IF NOT EXISTS]
//     [[project_name.]dataset_name.]function_name
//     ([named_parameter[, ...]])
//   RETURNS data_type
//   REMOTE WITH CONNECTION connection_path
//   [OPTIONS (function_option_list)]
create_remote_function
 : CREATE ( OR REPLACE )? ( TEMPORARY | TEMP )? FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier
   '(' named_parameters? ')'
   RETURNS data_type
   REMOTE WITH CONNECTION connection_path=path_expression
   ( OPTIONS '(' option_parameters ')' )?
 ;

// CREATE [ OR REPLACE ] [ { TEMPORARY | TEMP } ] AGGREGATE FUNCTION [ IF NOT EXISTS ]
//   [[project_name.]dataset_name.]function_name ( [ function_parameter[, ...] ] )
//   [ RETURNS data_type ]
//   AS ( sql_function_body )
//   [ OPTIONS ( function_option_list ) ]
create_aggregate_function
 : CREATE ( OR REPLACE )? ( TEMPORARY | TEMP )? AGGREGATE FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier '(' function_parameters? ')'
   ( RETURNS data_type )?
   AS '(' expression ')'
   ( OPTIONS '(' option_parameters ')' )?
 ;

function_parameters
 : function_parameter ( ',' function_parameter )*
 ;

// function_parameter:
//   parameter_name data_type [ NOT AGGREGATE ]
function_parameter
 : parameter_name=path_expression data_type ( NOT AGGREGATE )?
 ;

// CREATE [ OR REPLACE ] [ { TEMPORARY | TEMP } ] AGGREGATE FUNCTION [ IF NOT EXISTS ]
//   [[project_name.]dataset_name.]function_name ([ function_parameter[, ...] ])
//   RETURNS return_data_type
//   LANGUAGE js
//   [ OPTIONS ( function_option_list ) ]
//   AS function_body
create_aggregate_js_function
 : CREATE ( OR REPLACE )? ( TEMPORARY | TEMP )? AGGREGATE FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier '(' function_parameters? ')'
   RETURNS data_type
   LANGUAGE identifier
   ( OPTIONS '(' option_parameters ')' )?
   AS function_body=string_literal
 ;

// CREATE [ OR REPLACE ] TABLE FUNCTION [ IF NOT EXISTS ]
//   [[project_name.]dataset_name.]function_name ( [ table_function_parameter [, ...] ] )
//   [RETURNS TABLE < column_declaration [, ...] > ]
//   [OPTIONS (table_function_options_list) ]
//   AS sql_query
create_table_function
 : CREATE ( OR REPLACE )? TABLE FUNCTION ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier '(' table_function_parameters? ')'
   ( RETURNS TABLE '<' column_declarations '>' )?
   ( OPTIONS '(' option_parameters ')' )?
   AS expression
 ;

table_function_parameters
 : table_function_parameter ( ',' table_function_parameter )*
 ;

// table_function_parameter:
//   parameter_name { data_type | ANY TYPE }
table_function_parameter
 : parameter_name=path_expression ( data_type | ANY TYPE )
 ;

column_declarations
 : column_declaration ( ',' column_declaration )*
 ;

// column_declaration:
//   column_name data_type
column_declaration
 : column_name=path_expression data_type
 ;

// CREATE [OR REPLACE] PROCEDURE [IF NOT EXISTS]
// [[project_name.]dataset_name.]procedure_name ( [procedure_argument[, ...]] )
// [OPTIONS(procedure_option_list)]
// BEGIN
// multi_statement_query
// END
create_procedure
 : CREATE ( OR REPLACE )? PROCEDURE ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier '(' procedure_arguments? ')'
   ( OPTIONS '(' option_parameters ')' )?
   BEGIN
   ';'* statement ( ';'+ statement )* ';'*
   END
 ;

procedure_arguments
 : procedure_argument ( ',' procedure_argument )*
 ;

// procedure_argument:
//   [IN | OUT | INOUT] argument_name argument_type
procedure_argument
 : ( IN | OUT | INOUT )? argument_name=path_expression data_type
 ;

// CREATE [OR REPLACE] PROCEDURE [IF NOT EXISTS]
// [[project_name.]dataset_name.]procedure_name ( [procedure_argument[, ...]] )
// [EXTERNAL SECURITY INVOKER]
// WITH CONNECTION connection_project_id.connection_region.connection_id
// [OPTIONS(procedure_option_list)]
// LANGUAGE language [AS pyspark_code]
create_stored_procedure
 : CREATE ( OR REPLACE )? PROCEDURE ( IF NOT EXISTS )?
   ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier '(' procedure_arguments? ')'
   ( EXTERNAL SECURITY INVOKER )?
   WITH CONNECTION path_expression
   ( OPTIONS '(' option_parameters ')' )?
   LANGUAGE language=identifier ( AS pyspark_code=string_literal )?
 ;

// CREATE [ OR REPLACE ] ROW ACCESS POLICY [ IF NOT EXISTS ]
// row_access_policy_name ON table_name
// [GRANT TO (grantee_list)]
// FILTER USING (filter_expression)
create_row_access_policy
 : CREATE ( OR REPLACE )? ROW ACCESS POLICY ( IF NOT EXISTS )?
   row_access_policy_name=path_expression ON table_name=path_expression
   ( GRANT TO '(' grantee_list=expressions ')' )?
   FILTER USING '(' filter_expression=expression ')'
 ;

// CREATE CAPACITY `project_id.location_id.commitment_id`
// OPTIONS (capacity_commitment_option_list)
create_capacity
 : CREATE CAPACITY expression OPTIONS '(' option_parameters ')'
 ;

// CREATE RESERVATION
// `project_id.location_id.reservation_id`
// OPTIONS (reservation_option_list)
create_reservation
 : CREATE RESERVATION expression OPTIONS '(' option_parameters ')'
 ;

// CREATE ASSIGNMENT
// `project_id.location_id.reservation_id.assignment_id`
// OPTIONS (assignment_option_list)
create_assignment
 : CREATE ASSIGNMENT expression OPTIONS '(' option_parameters ')'
 ;

// CREATE SEARCH INDEX [ IF NOT EXISTS ] index_name
// ON table_name({ALL COLUMNS [WITH COLUMN OPTIONS(column [, ...])] | column [, ...]})
// [OPTIONS(index_option_list)]
create_search_index
 : CREATE SEARCH INDEX ( IF NOT EXISTS )? index_name=path_expression
   ON table_name=path_expression '(' ( ALL COLUMNS ( WITH COLUMN OPTIONS '(' columns ')' )? | columns ) ')'
   ( OPTIONS '(' option_parameters ')' )?
 ;

columns
 : column ( ',' column )*
 ;

// column
//   column_name [data_type] [OPTIONS(index_column_option_list)]
column
 : column_name=path_expression data_type? ( OPTIONS '(' option_parameters ')' )?
 ;

// CREATE [ OR REPLACE ] VECTOR INDEX [ IF NOT EXISTS ] index_name
// ON table_name(column_name)
// [STORING(stored_column_name [, ...])]
// OPTIONS(index_option_list)
create_vector_index
 : CREATE ( OR REPLACE )? VECTOR INDEX ( IF NOT EXISTS )? index_name=path_expression
   ON table_name=path_expression '(' column_name=path_expression ')'
   ( STORING '(' path_expressions ')' )?
   OPTIONS '(' option_parameters ')'
 ;

// ALTER SCHEMA [IF EXISTS] [project_name.]dataset_name
// SET DEFAULT COLLATE collate_specification
alter_schema_set_default_collate
 : ALTER SCHEMA ( IF EXISTS )? ( project_name=identifier '.' )? dataset_name=identifier
   SET DEFAULT COLLATE collate_specification=string_literal
 ;

// ALTER SCHEMA [IF EXISTS] [project_name.]dataset_name
// SET OPTIONS(schema_set_options_list)
alter_schema_set_options
 : ALTER SCHEMA ( IF EXISTS )? ( project_name=identifier '.' )? dataset_name=identifier
   SET OPTIONS '(' option_parameters ')'
 ;

// ALTER SCHEMA [IF EXISTS] [project_name.]dataset_name
// ADD REPLICA replica_name [OPTIONS(add_replica_options_list)]
alter_schema_add_replica
 : ALTER SCHEMA ( IF EXISTS )? ( project_name=identifier '.' )? dataset_name=identifier
   ADD REPLICA replica_name=path_expression ( OPTIONS '(' option_parameters ')' )?
 ;

// ALTER SCHEMA [IF EXISTS] dataset_name
// DROP REPLICA replica_name
alter_schema_drop_replica
 : ALTER SCHEMA ( IF EXISTS )? dataset_name=path_expression
   DROP REPLICA replica_name=expression
 ;

// ALTER TABLE [IF EXISTS] table_name
// SET OPTIONS(table_set_options_list)
alter_table_set_options
 : ALTER TABLE ( IF EXISTS )? table_name=path_expression
   SET OPTIONS '(' option_parameters ')'
 ;

// ALTER TABLE table_name
// ADD COLUMN [IF NOT EXISTS] column [, ...]
alter_table_add_column
 : ALTER TABLE table_name=path_expression
   ADD COLUMN ( IF NOT EXISTS )? column ( ',' ADD COLUMN ( IF NOT EXISTS )? column )*
 ;

// ALTER TABLE [[project_name.]dataset_name.]fk_table_name
// ADD [CONSTRAINT [IF NOT EXISTS] constraint_name] FOREIGN KEY (fk_column_name[, ...])
// REFERENCES pk_table_name(pk_column_name[,...]) NOT ENFORCED
// [ADD...]
alter_table_add_foreign_key
 : ALTER TABLE ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? fk_table_name=identifier
   add_foreign_key ( ',' add_foreign_key )*
 ;

add_foreign_key
 : ADD ( CONSTRAINT ( IF NOT EXISTS )? constraint_name=identifier )? FOREIGN KEY '(' columns ')'
   REFERENCES pk_table_name=identifier '(' columns ')' NOT ENFORCED
 | ADD PRIMARY KEY '(' columns ')' NOT ENFORCED
 ;

// ALTER TABLE [[project_name.]dataset_name.]table_name
// ADD PRIMARY KEY(column_list) NOT ENFORCED
alter_table_add_primary_key
 : ALTER TABLE ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? fk_table_name=identifier
   ADD PRIMARY KEY '(' columns ')' NOT ENFORCED
 ;

// ALTER TABLE [IF EXISTS] table_name
// RENAME TO new_table_name
alter_table_rename
 : ALTER TABLE ( IF EXISTS )? table_name=path_expression
   RENAME TO new_table_name=path_expression
 ;

// ALTER TABLE [IF EXISTS] table_name
// RENAME COLUMN [IF EXISTS] column_to_column[, ...]
alter_table_rename_column
 : ALTER TABLE ( IF EXISTS )? table_name=path_expression
   rename_column ( ',' rename_column )*
 ;

rename_column
 : RENAME COLUMN ( IF EXISTS )? column_to_column ( ',' column_to_column )*
 ;

// column_to_column
//   column_name TO new_column_name
column_to_column
 : column_name=identifier TO new_column_name=identifier
 ;

// ALTER TABLE table_name
// DROP COLUMN [IF EXISTS] column_name [, ...]
alter_table_drop_column
 : expression // TODO
 ;

// ALTER TABLE [[project_name.]dataset_name.]table_name
// DROP CONSTRAINT [IF EXISTS] constraint_name
alter_table_drop_constraint
 : expression // TODO
 ;

// ALTER TABLE [[project_name.]dataset_name.]table_name
// DROP PRIMARY KEY [IF EXISTS]
alter_table_drop_primary_key
 : expression // TODO
 ;

// ALTER TABLE table_name
// SET DEFAULT COLLATE collate_specification
alter_table_set_default_collate
 : expression // TODO
 ;

// ALTER { TABLE | VIEW } [IF EXISTS] name
// ALTER COLUMN [IF EXISTS] column_name
// SET OPTIONS({ column_set_options_list | view_column_set_options_list })
alter_table_column_set_options
 : expression // TODO
 ;

// ALTER TABLE [IF EXISTS] table_name
// ALTER COLUMN [IF EXISTS] column DROP NOT NULL
alter_table_column_drop_not_null
 : expression // TODO
 ;

// ALTER TABLE [IF EXISTS] table_name
// ALTER COLUMN [IF EXISTS] column_name SET DATA TYPE column_schema
alter_table_column_set_data_type
 : expression // TODO
 ;

// ALTER TABLE [IF EXISTS] table_name ALTER COLUMN [IF EXISTS] column_name
// SET DEFAULT default_expression
alter_table_column_set_default
 : expression // TODO
 ;

// ALTER TABLE [IF EXISTS] table_name ALTER COLUMN [IF EXISTS] column_name
// DROP DEFAULT
alter_table_column_drop_default
 : expression // TODO
 ;

// ALTER VIEW [IF EXISTS] view_name
// SET OPTIONS(view_set_options_list)
alter_view
 : expression // TODO
 ;

// ALTER MATERIALIZED VIEW [IF EXISTS] materialized_view_name
// SET OPTIONS(materialized_view_set_options_list)
alter_materialized_view
 : expression // TODO
 ;

// ALTER ORGANIZATION
// SET OPTIONS ( organization_set_options_list )
alter_organication
 : expression // TODO
 ;

// ALTER PROJECT project_id
// SET OPTIONS (project_set_options_list)
alter_project
 : expression // TODO
 ;

// ALTER BI_CAPACITY `project_id.location_id.default`
// SET OPTIONS(bi_capacity_options_list)
alter_bi_capacity
 : expression // TODO
 ;

// ALTER CAPACITY `project_id.location_id.commitment_id`
// SET OPTIONS (alter_capacity_commitment_option_list)
alter_capacity
 : expression // TODO
 ;

// ALTER RESERVATION `project_id.location_id.reservation_id`
// SET OPTIONS (alter_reservation_option_list)
alter_reservation
 : expression // TODO
 ;

// UNDROP SCHEMA [IF NOT EXISTS] [project_name.]dataset_name
undrop_schema
 : UNDROP SCHEMA ( IF NOT EXISTS )? ( project_name=identifier '.' )? dataset_name=identifier
 ;

// DROP [EXTERNAL] SCHEMA [IF EXISTS]
// [project_name.]dataset_name
// [ CASCADE | RESTRICT ]
drop_schema
 : DROP EXTERNAL? SCHEMA ( IF EXISTS )?
   ( project_name=identifier '.' )? dataset_name=identifier
   ( CASCADE | RESTRICT )?
 ;

// DROP TABLE [IF EXISTS] table_name
drop_table
 : DROP TABLE ( IF EXISTS )? path_expression
 ;

// DROP SNAPSHOT TABLE [IF EXISTS] table_snapshot_name
drop_snapshot_table
 : DROP SNAPSHOT TABLE ( IF EXISTS )? path_expression
 ;

// DROP EXTERNAL TABLE [IF EXISTS] table_name
drop_external_table
 : DROP EXTERNAL TABLE ( IF EXISTS )? path_expression
 ;

// DROP VIEW [IF EXISTS] view_name
drop_view
 : DROP VIEW ( IF EXISTS )? path_expression
 ;

// DROP MATERIALIZED VIEW [IF EXISTS] mv_name
drop_materialized_view
 : DROP MATERIALIZED VIEW ( IF EXISTS )? path_expression
 ;

// DROP FUNCTION [IF EXISTS] [[project_name.]dataset_name.]function_name
drop_function
 : DROP FUNCTION ( IF EXISTS )? ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier
 ;

// DROP TABLE FUNCTION [IF EXISTS] [[project_name.]dataset_name.]function_name
drop_table_function
 : DROP TABLE FUNCTION ( IF EXISTS )? ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? function_name=identifier
 ;

// DROP PROCEDURE [IF EXISTS] [[project_name.]dataset_name.]procedure_name
drop_procedure
 : DROP PROCEDURE ( IF EXISTS )? ( ( project_name=identifier '.' )? dataset_name=identifier '.' )? procedure_name=identifier
 ;

// DROP ROW ACCESS POLICY [ IF EXISTS ] row_access_policy_name ON table_name
//
// DROP ALL ROW ACCESS POLICIES ON table_name
drop_row_access_policy
 : DROP ROW ACCESS POLICY ( IF EXISTS )? row_access_policy_name=path_expression ON table_name=path_expression
 | DROP ALL ROW ACCESS POLICIES ON table_name=path_expression
 ;

// DROP CAPACITY [IF EXISTS] project_id.location.capacity-commitment-id
drop_capacity
 : DROP CAPACITY ( IF EXISTS )? path_expression
 ;

// DROP RESERVATION [IF EXISTS] project_id.location.reservation_id
drop_reservation
 : DROP RESERVATION ( IF EXISTS )? path_expression
 ;

// DROP ASSIGNMENT [IF EXISTS] project_id.location.reservation_id.assignment_id
drop_assignment
 : DROP ASSIGNMENT ( IF EXISTS )? path_expression
 ;

// DROP SEARCH INDEX [ IF EXISTS ] index_name ON table_name
drop_search_index
 : DROP SEARCH INDEX ( IF EXISTS )? index_name=path_expression ON table_name=path_expression
 ;

// DROP VECTOR INDEX [ IF EXISTS ] index_name ON table_name
drop_vector_index
 : DROP SEARCH INDEX ( IF EXISTS )? index_name=path_expression ON table_name=path_expression
 ;

// view_column_name_list
//   view_column[, ...]
view_column_name_list
 : view_column ( ',' view_column )*
 ;

// view_column
//   column_name [OPTIONS(view_column_option_list)]
view_column
 : column_name=path_expression ( OPTIONS '(' option_parameters ')' )?
 ;

column_constraint_definitions
 : column_constraint_definition ( ',' column_constraint_definition )*
 ;

// column:=
//   column_definition
//
// constraint_definition:=
//   [primary_key]
//   | [[CONSTRAINT constraint_name] foreign_key, ...]
column_constraint_definition
 : column_definition
 | primary_key
 | ( CONSTRAINT constraint_name=identifier )? foreign_key ( ',' ( CONSTRAINT constraint_name=identifier )? foreign_key )*
 ;

// column_definition
//   column_name data_type
column_definition
 : column_name=path_expression data_type
 ;

// primary_key :=
//   PRIMARY KEY (column_name[, ...]) NOT ENFORCED
primary_key
 : PRIMARY KEY '(' column_names=path_expressions ')' NOT ENFORCED
 ;

// foreign_key :=
//   FOREIGN KEY (column_name[, ...]) foreign_reference
foreign_key
 : FOREIGN KEY '(' column_names=path_expressions ')' foreign_reference
 ;

// foreign_reference :=
//   REFERENCES primary_key_table(column_name[, ...]) NOT ENFORCED
foreign_reference
 : REFERENCES primary_key_table=identifier '(' column_names=path_expressions ')' NOT ENFORCED
 ;

// CREATE SCHEMA [ IF NOT EXISTS ]
// [project_name.]dataset_name
// [DEFAULT COLLATE collate_specification]
// [OPTIONS(schema_option_list)]
create_schema
 : CREATE SCHEMA ( IF NOT EXISTS )?
   ( project_name=identifier '.' )? dataset_name=identifier
   ( DEFAULT COLLATE collate_specification=string_literal )?
   ( OPTIONS '(' option_parameters ')' )?
 ;

// query_expression:
//   [ WITH [ RECURSIVE ] { non_recursive_cte | recursive_cte }[, ...] ]
//   { select | ( query_expression ) | set_operation }
//   [ ORDER BY expression [{ ASC | DESC }] [, ...] ]
//   [ LIMIT count [ OFFSET skip_rows ] ]
//
// set_operation
//   query_expression
//   [ { INNER | { FULL | LEFT } [ OUTER ] } ]
//   {
//     UNION { ALL | DISTINCT } |
//     INTERSECT DISTINCT |
//     EXCEPT DISTINCT
//   }
//   [ { BY NAME [ ON (column_list) ] | [ STRICT ] CORRESPONDING [ BY (column_list) ] } ]
//   query_expression
query_expression
 : WITH RECURSIVE? ( non_recursive_cte | recursive_cte ) ( ',' ( non_recursive_cte | recursive_cte ) )*
   ( select | '(' query_expression ')' | query_expression set_operation_tail ) query_expr_tail
 | select query_expr_tail
 | '(' query_expression ')' query_expr_tail
 | query_expression set_operation_tail query_expr_tail
 ;

query_expr_tail
 : ( ORDER BY order_by=expression ( ASC | DESC )? ( ',' expression ( ASC | DESC )? )* )?
   ( LIMIT count=expression ( OFFSET skip_rows=expression )? )?
 ;

set_operation_tail
 : ( INNER | ( FULL | LEFT ) OUTER? )?
   ( UNION ( ALL | DISTINCT ) | INTERSECT DISTINCT | EXCEPT DISTINCT )
   ( ( BY NAME ( ON '(' column_list_3=path_expressions ')' )? | STRICT? CORRESPONDING ( BY '(' column_list_4=path_expressions ')' )? ) )?
   query_expression
 ;

// non_recursive_cte:
//   cte_name AS ( query_expression )
non_recursive_cte
 : cte_name=identifier AS '(' query_expression ')'
 ;

// recursive_cte:
//   cte_name AS ( recursive_union_operation )
//
recursive_cte
 : cte_name=identifier AS ( recursive_union_operation )
 ;

// recursive_union_operation:
//   base_term union_operator recursive_term
//
// base_term:
//   query_expression
//
// union_operator:
//   UNION ALL
//
// recursive_term:
//   query_expression
recursive_union_operation
 : base_term=query_expression UNION ALL recursive_term=query_expression
 ;

// select:
//   SELECT
//     [ WITH differential_privacy_clause ]
//     [ { ALL | DISTINCT } ]
//     [ AS { STRUCT | VALUE } ]
//     select_list
//   [ FROM from_clause[, ...] ]
//   [ WHERE bool_expression ]
//   [ GROUP BY group_by_specification ]
//   [ HAVING bool_expression ]
//   [ QUALIFY bool_expression ]
//   [ WINDOW window_clause ]
select
 : SELECT
     ( WITH differential_privacy_clause )?
     ( ALL | DISTINCT )?
     ( AS ( STRUCT | VALUE ) )?
     select_list
   ( FROM from_clauses )?
   ( WHERE expression )?
   ( GROUP BY group_by_specification )?
   ( HAVING expression )?
   ( QUALIFY expression )?
   ( WINDOW window_clause )?
 ;

// group_by_specification:
//   {
//     groupable_items
//     | ALL
//     | grouping_sets_specification
//     | rollup_specification
//     | cube_specification
//     | ()
//   }
group_by_specification
 : groupable_items=expressions
 | ALL
 | grouping_sets_specification
 | rollup_specification
 | cube_specification
 | '(' ')'
 ;

// GROUP BY GROUPING SETS ( grouping_list )
grouping_sets_specification
 : GROUP BY GROUPING SETS '(' grouping_list ')'
 ;

// grouping_list:
//   {
//     rollup_specification
//     | cube_specification
//     | groupable_item
//     | groupable_item_set
//   }[, ...]
grouping_list
 : grouping_list_item ( ',' grouping_list_item )*
 ;

grouping_list_item
 : rollup_specification
 | cube_specification
 | groupable_item=expression
 | groupable_item_set
 ;

// GROUP BY CUBE ( grouping_list )
cube_specification
 : GROUP BY CUBE '(' grouping_list ')'
 ;

// groupable_item_set:
//   ( groupable_item[, ...] )
groupable_item_set
 : '(' expressions ')'
 ;

// GROUP BY ROLLUP ( grouping_list )
rollup_specification
 : GROUP BY ROLLUP '(' grouping_list ')'
 ;

window_clause
 : named_window_expression ( ',' named_window_expression )*
 ;

// named_window_expression:
//   named_window AS { named_window | ( [ window_specification ] ) }
named_window_expression
 : named_window_1=path_expression AS ( named_window_2=path_expression | '(' window_specification ')' )
 ;

// window_specification:
//   [ named_window ]
//   [ PARTITION BY partition_expression [, ...] ]
//   [ ORDER BY expression [ { ASC | DESC } ] [, ...] ]
//   [ window_frame_clause ]
window_specification
 : named_window=path_expression?
   ( PARTITION BY expressions )?
   ( ORDER BY expressions_asc_desc )?
   window_frame_clause?
 ;

// window_frame_clause:
//   { rows_range } { frame_start | frame_between }
//
// rows_range:
//   { ROWS | RANGE }
window_frame_clause
 : ( ROWS | RANGE ) ( frame_start | frame_between )
 ;

// frame_start:
//   { unbounded_preceding | numeric_preceding | [ current_row ] }
frame_start
 : UNBOUNDED PRECEDING
 | expression PRECEDING
 | ( CURRENT ROW )?
 ;

// frame_between:
//   {
//     BETWEEN  unbounded_preceding AND frame_end_a
//     | BETWEEN numeric_preceding AND frame_end_a
//     | BETWEEN current_row AND frame_end_b
//     | BETWEEN numeric_following AND frame_end_c
//   }
frame_between
 : BETWEEN UNBOUNDED PRECEDING AND frame_end_a
 | BETWEEN expression PRECEDING AND frame_end_a
 | BETWEEN CURRENT ROW AND frame_end_b
 | BETWEEN expression FOLLOWING AND frame_end_c
 ;

// frame_end_a:
//   { numeric_preceding | current_row | numeric_following | unbounded_following }
frame_end_a
 : expression PRECEDING
 | CURRENT ROW
 | expression FOLLOWING
 | UNBOUNDED FOLLOWING
 ;

// frame_end_b:
//   { current_row | numeric_following | unbounded_following }
frame_end_b
 : CURRENT ROW
 | expression FOLLOWING
 | UNBOUNDED FOLLOWING
 ;

// frame_end_c:
//   { numeric_following | unbounded_following }
frame_end_c
 : expression FOLLOWING
 | UNBOUNDED FOLLOWING
 ;

// WITH DIFFERENTIAL_PRIVACY OPTIONS( privacy_parameters )
differential_privacy_clause
 : DIFFERENTIAL_PRIVACY OPTIONS '(' option_parameters ')'
 ;

from_clauses
 : from_clause ( ',' from_clause )*
 ;

// from_clause:
//   from_item
//   [ { pivot_operator | unpivot_operator } ]
//   [ tablesample_operator ]
from_clause
 : from_item ( pivot_operator | unpivot_operator )? tablesample_operator?
 ;

// from_item:
//   {
//     table_name [ as_alias ] [ FOR SYSTEM_TIME AS OF timestamp_expression ]
//     | { join_operation | ( join_operation ) }
//     | ( query_expression ) [ as_alias ]
//     | field_path
//     | unnest_operator
//     | cte_name [ as_alias ]
//   }
//
// join_operation:
//   { cross_join_operation | condition_join_operation }
//
// cross_join_operation:
//   from_item cross_join_operator from_item
//
// condition_join_operation:
//   from_item condition_join_operator from_item join_condition
from_item
 : table_name=identifier as_alias? ( FOR SYSTEM_TIME AS OF timestamp_expression=expression )?
 | from_item cross_join_operator from_item
 | from_item condition_join_operator from_item join_condition
 | '(' ( from_item cross_join_operator from_item | from_item condition_join_operator from_item join_condition) ')'
 | '(' query_expression ')' as_alias?
 | field_path=path_expression
 | unnest_operator
 | cte_name=path_expression as_alias?
 ;

// unnest_operator:
//   {
//     UNNEST( array ) [ as_alias ]
//     | array_path [ as_alias ]
//   }
//   [ WITH OFFSET [ as_alias ] ]
unnest_operator
 : ( UNNEST '(' array=expression ')' as_alias?
   | array_path=path_expression as_alias?
   )
   ( WITH OFFSET as_alias? )?
 ;

// cross_join_operator:
//   { CROSS JOIN | , }
cross_join_operator
 : CROSS JOIN
 | ','
 ;

// condition_join_operator:
//   {
//     [INNER] JOIN
//     | FULL [OUTER] JOIN
//     | LEFT [OUTER] JOIN
//     | RIGHT [OUTER] JOIN
//   }
condition_join_operator
 : INNER? JOIN
 | FULL OUTER? JOIN
 | LEFT OUTER? JOIN
 | RIGHT OUTER? JOIN
 ;

// join_condition:
//   { on_clause | using_clause }
join_condition
 : on_clause
 | using_clause
 ;

// on_clause:
//   ON bool_expression
on_clause
 : ON expression
 ;

// using_clause:
//   USING ( column_list )
using_clause
 : USING '(' column_list=path_expressions ')'
 ;

// pivot_operator:
//   PIVOT(
//     aggregate_function_call [as_alias][, ...]
//     FOR input_column
//     IN ( pivot_column [as_alias][, ...] )
//   ) [AS alias]
pivot_operator
 : PIVOT '('
     function_call as_alias? ( ',' function_call as_alias? )*
     FOR input_column=identifier
     IN '(' expressions_as_alias ')'
   ')' ( AS alias=identifier )?
 ;

// unpivot_operator:
//   UNPIVOT [ { INCLUDE NULLS | EXCLUDE NULLS } ] (
//     { single_column_unpivot | multi_column_unpivot }
//   ) [unpivot_alias]
unpivot_operator
 : UNPIVOT ( INCLUDE NULLS | EXCLUDE NULLS )? '('
     ( single_column_unpivot | multi_column_unpivot )
   ')' unpivot_alias=as_alias
 ;

// single_column_unpivot:
//   values_column
//   FOR name_column
//   IN (columns_to_unpivot)
single_column_unpivot
 : values_column=expressions FOR name_column=path_expression IN '(' columns_to_unpivot ')'
 ;

// multi_column_unpivot:
//   values_column_set
//   FOR name_column
//   IN (column_sets_to_unpivot)
//
// values_column_set:
//   (values_column[, ...])
multi_column_unpivot
 : '(' expressions ')' FOR name_column=path_expression IN '(' column_sets_to_unpivot ')'
 ;

// columns_to_unpivot:
//   unpivot_column [row_value_alias][, ...]
columns_to_unpivot
 : expression as_alias? ( ',' expression row_value_alias=identifier? )*
 ;

// column_sets_to_unpivot:
//   (unpivot_column [row_value_alias][, ...])
column_sets_to_unpivot
 : '(' expression as_alias? ( ',' expression row_value_alias=identifier? )* ')'
 ;

// TABLESAMPLE SYSTEM ( percent PERCENT )
tablesample_operator
 : TABLESAMPLE SYSTEM '(' percent=expression PERCENT ')'
 ;

// privacy_parameters:
//   epsilon = expression,
//   delta = expression,
//   [ max_groups_contributed = expression ],
//   privacy_unit_column = column_name
option_parameters
 : option_parameter ( ',' option_parameter )*
 ;

option_parameter
 : identifier '=' expression
 ;

// select_list:
//   { select_all | select_expression } [, ...]
select_list
 : select_list_item ( ',' select_list_item )*
 ;

// select_expression:
//   expression [ [ AS ] alias ]
select_list_item
 : select_all
 | expression as_alias?
 ;

// select_all:
//   [ expression. ]*
//   [ EXCEPT ( column_name [, ...] ) ]
//   [ REPLACE ( expression AS column_name [, ...] ) ]
select_all
 : ( expression '.' )? '*'
   ( EXCEPT '(' column_names=path_expressions ')' )?
   ( REPLACE '(' as_column_names ')' )?
 ;

expression
 : '(' expression ')'
 | select
 | path_expression
 | expression '.' path_expression
 | expression '[' expression ']'
 | ( '+' | '-' | '~' ) expression
 | expression ( '*' | '/' | '||' ) expression
 | expression ( '+' | '-' ) expression
 | expression ( '<' '<' | '>' '>' ) expression
 | expression '&' expression
 | expression '^' expression
 | expression '|' expression
 | expression ( '=' | NEQ | '<' | '>' | '<=' | '>=' | NOT? ( LIKE | BETWEEN | IN ) ) expression
 | expression IS NOT? ( NULL | TRUE | FALSE )
 | expression IS NOT? DISTINCT FROM expression
 | NOT expression
 | expression AND expression
 | expression OR expression
 | expression AS? alias=identifier
 | EXISTS '(' expression ')'
 | UNNEST '(' expression ')'
 | expression NOT? LIKE ( ANY | SOME | ALL ) expression
 | function_call
 | window_function
 | literal
 | case_expression
 | case_
 | coalesce
 | if_
 | ifnull
 | nullif
 ;

expressions
 : expression ( ',' expression )*
 ;

// CASE expr
//   WHEN expr_to_match THEN result [ ... ]
//   [ ELSE else_result ]
//   END
case_expression
 : CASE expression ( WHEN expr_to_match=expression THEN result=expression )+
   ( ELSE else_result=expression )?
   END
 ;

// CASE
//   WHEN condition THEN result [ ... ]
//   [ ELSE else_result ]
//   END
case_
 : CASE ( WHEN expr_to_match=expression THEN result=expression )+
   ( ELSE else_result=expression )?
   END
 ;

// COALESCE(expr[, ...])
coalesce
 : COALESCE '(' expressions ')'
 ;

// IF(expr, true_result, else_result)
if_
 : IF '(' expr=expression ',' true_result=expression ',' else_result=expression  ')'
 ;

// IFNULL(expr, null_result)
ifnull
 : IFNULL '(' expression ',' null_result=expression ')'
 ;

// NULLIF(expr, expr_to_match)
nullif
 : NULLIF '(' expression ',' expr_to_match=expression ')'
 ;

expressions_as_alias
 : expressions as_alias? ( ',' expressions as_alias? )*
 ;

expressions_asc_desc
 : expression ( ASC | DESC )? ( ',' expression ( ASC | DESC )? )*
 ;

literal
 : string_literal
 | byte_literal
 | numeric_literal
 | big_numeric_literal
 | array_literal
 | struct_literal
 | date_literal
 | datetime_literal
 | timestamp_literal
 | range_literal
 | interval_literal
 | json_literal
 | INTEGER_LITERAL
 | FLOATING_POINT_LITERAL
 | NULL
 | TRUE
 | FALSE
 ;

numeric_literal
 : NUMERIC string_literal
 ;

big_numeric_literal
 : BIGNUMERIC string_literal
 ;

array_literal
 : ( ARRAY ( '<' data_type '>' )? )? '[' expressions? ']'
 ;

struct_literal
 : ( STRUCT ( '<' data_type ( ',' data_type )* '>' )? )? '(' expressions ')'
 ;

data_type
 : ( ARRAY ( '<' data_type '>' )?
   | STRUCT ( '<' data_type ( ',' data_type )* '>' )?
   | identifier data_type
   | identifier
   )
   ( '(' expressions ')' )? ( COLLATE string_literal )? ( NOT NULL )? ( OPTIONS '(' option_parameters ')' )?
 ;

string_literal
 : STRING_LITERAL
 | RAW_STRING_LITERAL
 ;

date_literal
 : DATE string_literal
 ;

datetime_literal
 : DATETIME string_literal
 ;

timestamp_literal
 : TIMESTAMP string_literal
 ;

range_literal
 : RANGE '<' ( DATE | DATETIME | TIMESTAMP ) '>' string_literal
 ;

interval_literal
 : INTERVAL ( expression datetime_part | string_literal datetime_part TO datetime_part )
 ;

json_literal
 : JSON string_literal
 ;

byte_literal
 : BYTES_LITERAL
 | RAW_BYTES_LITERAL
 ;

// TODO include all non-reserved
identifier
 : UNQUOTED_IDENTIFIER
 | QUOTED_IDENTIFIER
 | BIGNUMERIC | DATE | DATETIME | NUMERIC | TIMESTAMP | YEAR | QUARTER | MONTH | WEEK | DAY | HOUR | MINUTE | SECOND
 | MILLISECOND | MICROSECOND | JSON | OFFSET | NAME | STRICT | CORRESPONDING | DIFFERENTIAL_PRIVACY | OPTIONS | VALUE
 | REPLACE | SYSTEM | PERCENT | PIVOT | UNPIVOT | SYSTEM_TIME | ROW | INCLUDE | FORMAT | SETS | AVG | SCHEMA | TEMP
 | TEMPORARY | TABLE | CONSTRAINT | ENFORCED | PRIMARY | KEY | FOREIGN | REFERENCES | CLUSTER | CONNECTION | ARRAY_AGG
 | COPY | SNAPSHOT | CLONE | VIEW | DROP | SEARCH | INDEX | VECTOR | ASSIGNMENT | RESERVATION | POLICIES | POLICY
 | ACCESS | PROCEDURE | FUNCTION | REPLICA | COLUMNS | RETURNS | DETERMINISTIC | LANGUAGE | REMOTE | AGGREGATE | TYPE
 | OUT | INOUT | BEGIN | SECURITY | INVOKER | COALESCE | NULLIF | IFNULL | GRANT | FILTER | COLUMN | STORING | ALTER
 | ADD | RENAME
 ;

// as_alias:
//   [ AS ] alias
as_alias
 : AS? alias=identifier
 ;

function_call
 : ARRAY '(' expression ')' // ARRAY(subquery)
 | AVG '(' DISTINCT? expression ')' ( OVER over_clause )? // AVG([ DISTINCT ] expression ) [ OVER over_clause ]
 | AVG '(' expression ( ',' identifier '=>' expression )? ')' // AVG( expression, [ contribution_bounds_per_group => (lower_bound, upper_bound) ] )
 | CAST '(' expression AS typename=identifier format_clause? ')' // CAST(expression AS typename [format_clause])
 | COLLATE '(' expression ',' expression ')' // COLLATE(value, collate_specification)
 | EXTRACT '(' identifier FROM expression ')' // EXTRACT(part FROM date_expression)
 | array_agg
 | identifier '(' expressions? ')'
 ;

// ARRAY_AGG(
//   [ DISTINCT ]
//   expression
//   [ { IGNORE | RESPECT } NULLS ]
//   [ ORDER BY key [ { ASC | DESC } ] [, ... ] ]
//   [ LIMIT n ]
// )
// [ OVER over_clause ]
array_agg
 : ARRAY_AGG '('
     DISTINCT?
     expression
     ( ( IGNORE | RESPECT ) NULLS )?
     order_by_keys?
     ( LIMIT expression )?
   ')'
   ( OVER over_clause )?
 ;

// ORDER BY key [ { ASC | DESC } ] [, ... ]
order_by_keys
 : order_by_key ( ',' order_by_key )*
 ;

// ORDER BY key [ { ASC | DESC } ]
order_by_key
 : ORDER BY key=path_expression ( ASC | DESC )?
 ;

// function_name ( [ argument_list ] ) OVER over_clause
window_function
 : identifier '(' ( expressions | '*' )? ')' OVER over_clause
 ;

// over_clause:
//   { named_window | ( [ window_specification ] ) }
over_clause
 : named_window=identifier
 | '(' window_specification ')'
 ;

// format_clause:
//   FORMAT format_model
//
// format_model:
//   format_string_expression
format_clause
 : FORMAT format_string_expression=expression
 ;

// SET variable_name = expression;
//
// SET (variable_name[, ...]) = (expression[, ...]);
set
 : SET variable_name=path_expression '=' expression
 | SET '(' path_expressions ')' '=' '(' expressions ')'
 ;

path_expressions
 : path_expression ( ',' path_expression )*
 ;

path_expression
 : identifier ( '.' ( identifier | reserved ) )*
 ;

as_column_names
 : as_column_name ( ',' as_column_name )*
 ;

as_column_name
 : expression AS column_name=identifier
 ;

reserved
 : ALL | AND | ANY | ARRAY | AS | ASC | ASSERT_ROWS_MODIFIED | AT | BETWEEN | BY | CASE | CAST | COLLATE | CONTAINS
 | CREATE | CROSS | CUBE | CURRENT | DEFAULT | DEFINE | DESC | DISTINCT | ELSE | END | ENUM | ESCAPE | EXCEPT | EXCLUDE
 | EXISTS | EXTRACT | FALSE | FETCH | FOLLOWING | FOR | FROM | FULL | GROUP | GROUPING | GROUPS | HASH | HAVING | IF
 | IGNORE | IN | INNER | INTERSECT | INTERVAL | INTO | IS | JOIN | LATERAL | LEFT | LIKE | LIMIT | LOOKUP | MERGE
 | NATURAL | NEW | NO | NOT | NULL | NULLS | OF | ON | OR | ORDER | OUTER | OVER | PARTITION | PRECEDING | PROTO
 | QUALIFY | RANGE | RECURSIVE | RESPECT | RIGHT | ROLLUP | ROWS | SELECT | SET | SOME | STRUCT | TABLESAMPLE | THEN
 | TO | TREAT | TRUE | UNBOUNDED | UNION | UNNEST | USING | WHEN | WHERE | WINDOW | WITH | WITHIN
 ;

datetime_part
 : YEAR
 | QUARTER
 | MONTH
 | WEEK
 | DAY
 | HOUR
 | MINUTE
 | SECOND
 | MILLISECOND
 | MICROSECOND
 ;