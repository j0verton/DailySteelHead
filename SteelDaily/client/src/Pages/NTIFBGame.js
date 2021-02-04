import { useEffect } from "react";
import fretboard from "../images/fretboard.svg"


const NTIFBGame = () => {

    useEffect(() => {
        console.log("run my shit")
    }, [])
    return (
        <div className="game-area">
            <h2>Name the interval</h2>
            <div className="score-container">
                <img
                    id="fretboard"
                    src={fretboard}
                    alt="steelguitar fretboard" />
            </div>
        </div>

    )
};
export default NTIFBGame;