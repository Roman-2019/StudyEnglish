const checkAnswer = () => {
    dragAndDrop();
    const cheks = document.querySelector('.js-answ');

    const checked = function () {
        if (cells[3].innerHTML == cells[0].innerHTML) {
            this.classList.add('visible');
        }
    };

    cheks.addEventListener('checked', checked);
};
checkAnswer();