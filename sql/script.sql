create table passport_issuer (
    passport_issuer_id int primary key generated always as identity,
    passport_issuer_name text unique not null
);

create table borrower (
    borrower_id int primary key generated always as identity,
    passport_serial int not null check (passport_serial >= 1000 and passport_serial <= 9999),
    passport_number int not null check (passport_number >= 100000 and passport_number <= 999999),
    passport_issuer_id int not null references passport_issuer,
    passport_issue_date date not null check (passport_issue_date > birthdate),
    constraint passport unique (passport_serial, passport_number, passport_issuer_id, passport_issue_date),
    full_name text not null,
    birthdate date not null,
    borrower_inn text unique not null,
    snils text unique not null,
    registration_address text not null,
    residential_address text null
);

create table credit_type (
    credit_type_id int primary key generated always as identity,
    credit_type_name text unique not null
);

create table creditor (
    creditor_id int primary key generated always as identity,
    creditor_name text unique not null,
    creditor_inn text unique not null
);

create table credit_application (
    credit_application_id int primary key generated always as identity,
    borrower_id int not null references borrower,
    credit_type_id int not null references credit_type,
    creditor_id int not null references creditor,
    application_date date not null,
    credit_amount int not null
);

create table credit (
    credit_id int primary key references credit_application,
    is_active bool not null default true,
    start_date date not null,
    end_date date null,
    interest_rate int not null check (interest_rate >= 0 and interest_rate <= 100)
);

create table payment (
    payment_id int primary key generated always as identity,
    credit_id int not null references credit,
    payment_date date not null,
    payment_amount int not null,
    remaining_amount int not null,
    debt int not null check (debt <= remaining_amount)
);

create table contributor (
    contributor_id int primary key generated always as identity,
    contributor_name text unique not null,
    contributor_inn text unique not null
);

create table contribution (
    contribution_id int primary key generated always as identity,
    contributor_id int not null references contributor,
    borrower_id int not null references borrower,
    contribution_date date not null
);

create table requester (
    requester_id int primary key generated always as identity,
    requester_name text unique not null,
    requester_inn text unique not null
);

create table request (
    request_id int primary key generated always as identity,
    requester_id int not null references requester,
    borrower_id int not null references borrower,
    request_date date not null
);

create table job_title (
    job_title_id int primary key generated always as identity,
    job_title_name text unique not null
);

create table app_user (
    app_user_id int primary key generated always as identity,
    full_name text not null,
    job_title_id int not null references job_title,
    access_level int not null check (access_level >= 1 and access_level <= 3),
    email text not null
);
