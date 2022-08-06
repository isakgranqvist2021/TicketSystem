CREATE TABLE ticket (
    id uuid DEFAULT uuid_generate_v4(),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at TIMESTAMP DEFAULT NULL,
    amount int NOT NULL DEFAULT 0,
    title VARCHAR(9999) DEFAULT NULL,
    price int DEfAULT NULL,
    description VARCHAR(9999) DEFAULT NULL,
)