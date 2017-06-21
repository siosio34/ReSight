from app import db_instance

def initialize_db_instance():
    import app.Models.AppStoreModel as appStoreModel
    import app.Models.HandLearnModel as handLearnModel
    import app.Models.UserModel as userModel

    db_instance.create_all()
    # db_instance.session.commit()
    print('DB Initialize Succeed')
