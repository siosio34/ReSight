from app import app


def initialize_controller():
    from app.Controller.AppStoreController import appStoreBluePrint
    from app.Controller.SensorDataController import sensorDataBluePrint
    app.register_blueprint(appStoreBluePrint)
    app.register_blueprint(sensorDataBluePrint)
