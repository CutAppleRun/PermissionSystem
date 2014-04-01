// 容器对象
// 保存一组key对象，通过key返回该key所在的index
function List() {
    this.array = new Array();
    this.count = 0;

    // 添加一个key对象
    this.add = function (key) {
        this.array[key] = this.count;
        this.count++;
    }
    // 获得该key对象的位置，从1开始
    this.get = function (key) {
        var index = 1;
        for (var item in this.array) {
            if (item != key)
                index++;
            else
                return index;
        }
    }
    // 从数组中[删除]key对象
    this.remove = function (key) {
        var newArray = new Array();
        for (var item in this.array) {
            if (key == item)
                this.count--;
            else
                newArray[item] = this.array[item];
        }
        this.array = newArray;
    }

    // 获取当前数量
    this.getCount = function () {
        return this.count;
    }
    // 判断key是否在数组中
    this.exists = function (key) {
        if (this.array[key] == undefined)
            return false;
        else
            return true;
    }
}