CREATE EXTENSION pgcrypto;

-- create random unique alpha-num key as per https://stackoverflow.com/a/41988979/5066092
CREATE OR REPLACE FUNCTION generate_uid(size INT) RETURNS TEXT AS $$
DECLARE
  characters TEXT := 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  bytes BYTEA := gen_random_bytes(size);
  l INT := length(characters);
  i INT := 0;
  output TEXT := '';
BEGIN
  WHILE i < size LOOP
    output := output || substr(characters, get_byte(bytes, i) % l + 1, 1);
    i := i + 1;
  END LOOP;
  RETURN output;
END;
$$ LANGUAGE plpgsql VOLATILE;

CREATE TABLE PAYMENT_SOURCES (
  id TEXT PRIMARY KEY DEFAULT ('src_' || generate_uid(26)),
  card_type varchar DEFAULT 'card' NOT NULL,
  expiry_month INT NOT NULL,
  expiry_year INT NOT NULL,
  card_name VARCHAR,
  last4 CHAR(4) NOT NULL,
  scheme char(25),
  CONSTRAINT valid_month CHECK (expiry_month > 0 AND expiry_month < 13)
);


 

CREATE TABLE PAYMENTS (
    id TEXT PRIMARY KEY DEFAULT ('pay_' || generate_uid(26)),
    amount INTEGER NOT NULL,
    currency CHAR(3) NOT NULL,
    approved BOOLEAN,
    payment_status VARCHAR NOT NULL,
    auth_code CHAR(6),
    processed_on TIMESTAMP DEFAULT NOW() NOT NULL,
    reference VARCHAR,
    source_id TEXT REFERENCES PAYMENT_SOURCES(id),
    CONSTRAINT valid_status CHECK (payment_status in ('Captured', 'Authorized', 'Declined'))
);

