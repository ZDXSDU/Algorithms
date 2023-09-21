function SumList(arr) {
    if (arr.length == 1) {
        return arr[0];
    } else {
        return arr[0] + SumList(arr.slice(1));
    }
}

let lists = [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
console.log(SumList(lists));