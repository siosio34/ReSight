MYSQL_USERNAME = 'root'
MYSQL_PASSWORD = 'sjsdj123'
MYSQL_HOST = 'localhost'
MYSQL_DATABASE = 'resight'

SQLALCHEMY_DATABASE_URI = 'mysql+pymysql://{}:{}@{}/{}'.format(MYSQL_USERNAME,
                                                               MYSQL_PASSWORD,
                                                               MYSQL_HOST,
                                                               MYSQL_DATABASE)

SQLALCHEMY_ECHO = True
SQLALCHEMY_TRACK_MODIFICATIONS = True

