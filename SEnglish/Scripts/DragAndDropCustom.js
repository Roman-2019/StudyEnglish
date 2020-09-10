const dragAndDrop = () => {
    const card = document.querySelector('.js-card');
    const cells = document.querySelectorAll('.js-cell');

    let coordCardX;
    let coordCardY;
    let coordCellX;
    let coordCellY;
    let firstElementY;
    let x1, x2, x3, y1, y2, y3, card1, card2, newX, newY;

    const dragStart = function () {
        setTimeout(() => {
            coordCardX = cells[1].getBoundingClientRect();
            coordCardY = cells[2].getBoundingClientRect();
            coordCellX = cells[3].getBoundingClientRect();
            firstElementY = card.getBoundingClientRect();
            x1 = coordCardX.x;
            y1 = coordCardX.y;
            x2 = coordCardY.x;
            y2 = coordCardY.y;
            x3 = coordCellX.x;
            y3 = coordCellX.y;
            card1 = firstElementY.x;
            card2 = firstElementY.y;
            this.classList.add('hide');
        }, 0);      
    };

    const dragEnd = function () {
        this.classList.remove('hide');
    };

    const dragOver = function (evt) {
        evt.preventDefault();
    };

    const dragEnter = function (evt) {
        evt.preventDefault();
        this.classList.add('hovered');
    };

    const dragLeave = function () {
        this.classList.remove('hovered');
    };

    const dragDrop = function () {
        this.append(card);
        this.classList.remove('hovered');
        coordCellY = this.getBoundingClientRect();
        newX = coordCellY.x;
        newY = coordCellY.y;
        this.classList.add('visible');
        if (((newX - card1)>0) && (y3 >= (newY - card2))) {
            cells[5].classList.add('hide');
        }
        else {
            cells[4].classList.add('hide');
        }
    };

    cells.forEach(cell => {
        cell.addEventListener('dragover', dragOver);
        cell.addEventListener('dragenter', dragEnter);
        cell.addEventListener('dragleave', dragLeave);
        cell.addEventListener('drop', dragDrop);

    });


    card.addEventListener('dragstart', dragStart);
    card.addEventListener('dragend', dragEnd);

};

dragAndDrop();