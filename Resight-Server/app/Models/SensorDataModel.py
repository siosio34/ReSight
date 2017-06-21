from app import db_instance
import json


class SensorData(db_instance.Model):
    __tablename__ = 'SensorData'
    user_id = db_instance.Column(db_instance.Integer, primary_key=True)
    motion_code = db_instance.Column(db_instance.String(50), unique=True)
    muscle_data = db_instance.Column(db_instance.String(50), unique=True)

    def __init__(self, user_id, motion_code, muscle_data):
        self.user_id = user_id
        self.motion_code = motion_code
        self.muscle_data = muscle_data

    def __repr__(self):
        return json.dumps(
            {"user_id": self.user_id, "motion_code": self.motion_code, "muscle_data": self.muscle_data})

    def as_dict(self):
        return {x.name: getattr(self, x.name) for x in self.__table__columns}

    def add_database(self):
        try:
            db_instance.session.add(self)
        db_instance.session.commit()
        except:
            db_instance.session.rollback()
            raise
        finally:
            db_instance.session.close()

