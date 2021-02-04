import fretboard from "../images/fretboard.svg"


const NTIFBGame = () => {

    return (
        <div className="game-area">
            <h2>Name the interval</h2>
            <div className="score-container">
                <img src={fretboard} />
            </div>
        </div>

    )
};
export default NTIFBGame;