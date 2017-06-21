from flask import Blueprint,request
from app.Models.AppStoreModel import AppStore

appStoreBluePrint = Blueprint('appStoreBluePrint', __name__)


@appStoreBluePrint.route("/")
def hello():
    return "Hello world!"


@appStoreBluePrint.route('/app_store', methods=['GET', 'POST'])
def app_store_request():
    if request.method == 'GET':
        store_app_list = AppStore.query.all()
        print('---------------')
        print(store_app_list)
        print('---------------')
#       return store_app_list
        return 'ok'
    elif request.method == 'POST':
        result = request.get_json()
        print(result)
        app_name = result['app_name']
     app_store_link = result['app_store_link']
        app_image_link = result['app_image_link']
        store_ins = AppStore(app_name, app_store_link, app_image_link)
        store_ins.add_database()
        return 'post'







