from flask import Flask
from flask_sqlalchemy import SQLAlchemy


app = Flask(__name__)
app.config.from_object('app.config')
db_instance = SQLAlchemy(app)


@app.before_request
def process_before_request_url():
    app.logger.debug("Enter Process Request URL")
    # TODO Process url


from app.Models import initialize_db_instance
from app.Controller import initialize_controller

initialize_db_instance()
initialize_controller()






