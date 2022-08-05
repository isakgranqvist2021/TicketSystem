CREATE TABLE ticket (
    id uuid DEFAULT uuid_generate_v4(),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at TIMESTAMP DEFAULT null,
    amount int NOT NULL,
    title VARCHAR(9999) NOT NULL,
    price int NOT NULL DEfAULT 0,
    description VARCHAR(9999) NOT NULL
)