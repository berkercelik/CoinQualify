
const uri = 'https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false';
let coinapi = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
     
}



function _displayItems(data) {
    const tBody = document.getElementById('coinapi');
    tBody.innerHTML = '';

    data.forEach(item => {

        var formatter = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
            minimumFractionDigits: 0,
        });

        let tr = tBody.insertRow();

        let td0 = tr.insertCell(0);
        let textNode = document.createTextNode(item.market_cap_rank);
        td0.append(textNode);

        let td1 = tr.insertCell(1);
        let textNode1 = document.createTextNode(item.symbol);
        var upper = textNode1.nodeValue.toString().toUpperCase();        
        td1.append(upper);
        

        let td2 = tr.insertCell(2);
        let textNode2 = document.createTextNode(item.name);
        td2.append(textNode2);

        let td3 = tr.insertCell(3);
        let textNode3 = document.createTextNode(item.current_price);
        var format3 = formatter.format(textNode3.nodeValue);
        td3.append(format3);

        let td4 = tr.insertCell(4);
        let textNode4 = document.createTextNode(item.market_cap);        
        var format4 = formatter.format(textNode4.nodeValue);
        td4.append(format4);

        let td5 = tr.insertCell(5);
        let textNode5 = document.createTextNode(item.total_volume);
        var format5 = formatter.format(textNode5.nodeValue);
        td5.append(format5);

    });

    coinapi = data;
}

