CREATE TABLE ticket (
    ID uuid DEFAULT uuid_generate_v4(),
    TITLE VARCHAR(9999)
);