
        
CREATE TABLE addresses
(
  nickname    VARCHAR(50) NOT NULL,
  address1    VARCHAR(50) NULL    ,
  address2    VARCHAR(25) NULL    ,
  city        VARCHAR(50) NULL    ,
  province    VARCHAR(2)  NULL    ,
  country     VARCHAR(50) NULL    ,
  postal_code VARCHAR(10) NULL    ,
  PRIMARY KEY (nickname)
);

CREATE TABLE cart_items
(
  nickname VARCHAR(50) NOT NULL,
  game_id  INT         NOT NULL,
  PRIMARY KEY (nickname, game_id)
);

CREATE TABLE friendships
(
  nickname1  VARCHAR(50) NOT NULL,
  nickname2  VARCHAR(50) NOT NULL,
  created_at DATE        NOT NULL,
  PRIMARY KEY (nickname1, nickname2)
);

CREATE TABLE game_genres
(
  name VARCHAR(25) NOT NULL,
  PRIMARY KEY (name)
);

CREATE TABLE games
(
  game_id     INT          NOT NULL,
  name        VARCHAR(50)  NOT NULL,
  description VARCHAR(100) NOT NULL,
  price       FLOAT        NOT NULL,
  genre       VARCHAR(25)  NOT NULL,
  PRIMARY KEY (game_id)
);

CREATE TABLE order_items
(
  order_id INT NOT NULL,
  game_id  INT NOT NULL,
  quantity INT NOT NULL DEFAULT 1,
  PRIMARY KEY (order_id, game_id)
);

CREATE TABLE orders
(
  order_id   INT         NOT NULL,
  nickname   VARCHAR(50) NOT NULL,
  created_at DATETIME    NOT NULL,
  PRIMARY KEY (order_id)
);

CREATE TABLE preferences
(
  nickname VARCHAR(50) NOT NULL,
  platform VARCHAR(50) NOT NULL,
  genre    VARCHAR(25) NOT NULL,
  PRIMARY KEY (nickname)
);

CREATE TABLE reviews
(
  nickname    VARCHAR(50)  NOT NULL,
  game_id     INT          NOT NULL,
  rating      TINYINT      NOT NULL,
  description VARCHAR(512) NULL    ,
  approved    BIT          NOT NULL     DEFAULT 0,
  PRIMARY KEY (nickname, game_id)
);

CREATE TABLE users
(
  nickname   VARCHAR(50)  NOT NULL,
  email      VARCHAR(100) NOT NULL,
  first_name VARCHAR(50)  NULL    ,
  last_name  VARCHAR(50)  NULL    ,
  PRIMARY KEY (nickname)
);

CREATE TABLE wished_items
(
  nickname VARCHAR(50) NOT NULL,
  game_id  INT         NOT NULL,
  PRIMARY KEY (nickname, game_id)
);

ALTER TABLE orders
  ADD CONSTRAINT FK_users_TO_orders
    FOREIGN KEY (nickname)
    REFERENCES users (nickname);

ALTER TABLE order_items
  ADD CONSTRAINT FK_orders_TO_order_items
    FOREIGN KEY (order_id)
    REFERENCES orders (order_id);

ALTER TABLE order_items
  ADD CONSTRAINT FK_games_TO_order_items
    FOREIGN KEY (game_id)
    REFERENCES games (game_id);

ALTER TABLE cart_items
  ADD CONSTRAINT FK_users_TO_cart_items
    FOREIGN KEY (nickname)
    REFERENCES users (nickname);

ALTER TABLE cart_items
  ADD CONSTRAINT FK_games_TO_cart_items
    FOREIGN KEY (game_id)
    REFERENCES games (game_id);

ALTER TABLE wished_items
  ADD CONSTRAINT FK_users_TO_wished_items
    FOREIGN KEY (nickname)
    REFERENCES users (nickname);

ALTER TABLE wished_items
  ADD CONSTRAINT FK_games_TO_wished_items
    FOREIGN KEY (game_id)
    REFERENCES games (game_id);

ALTER TABLE friendships
  ADD CONSTRAINT FK_users_TO_friendships
    FOREIGN KEY (nickname1)
    REFERENCES users (nickname);

ALTER TABLE friendships
  ADD CONSTRAINT FK_users_TO_friendships1
    FOREIGN KEY (nickname2)
    REFERENCES users (nickname);

ALTER TABLE reviews
  ADD CONSTRAINT FK_users_TO_reviews
    FOREIGN KEY (nickname)
    REFERENCES users (nickname);

ALTER TABLE reviews
  ADD CONSTRAINT FK_games_TO_reviews
    FOREIGN KEY (game_id)
    REFERENCES games (game_id);

ALTER TABLE addresses
  ADD CONSTRAINT FK_users_TO_addresses
    FOREIGN KEY (nickname)
    REFERENCES users (nickname);

ALTER TABLE preferences
  ADD CONSTRAINT FK_users_TO_preferences
    FOREIGN KEY (nickname)
    REFERENCES users (nickname);

ALTER TABLE games
  ADD CONSTRAINT FK_game_genres_TO_games
    FOREIGN KEY (genre)
    REFERENCES game_genres (name);

ALTER TABLE preferences
  ADD CONSTRAINT FK_game_genres_TO_preferences
    FOREIGN KEY (genre)
    REFERENCES game_genres (name);

        
      