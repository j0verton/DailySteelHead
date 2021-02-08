import React from "react";

function FindUnisonNotes({ result, gameComponent }) {

    const handleNoteClick = e => {
        console.log(e);
        e.target.style.visibility = "visible"

    }
    return (
        <>
            {result.fretboard ? result.fretboard.intFretboard.map((fret, i) => {
                return fret.map((note, j) => {
                    return (
                        <circle
                            pointer-events="bounding-box"
                            key={`${i}-${j}`}
                            id={`note--${i}-${j}`}
                            //add a class correct or incorrect based on note
                            cx={21 + (110 * i)} cy={25 + (34 * j)} r="15"
                            //change fill color based on correct incorrect
                            fill="#39FF14"
                            visibility={(i === result.questions.slice(-1)[0][0] && j === result.questions.slice(-1)[0][1]) ? "visible" : "hidden"
                            }

                            // maybe saves wrong guesses or total guesses til all have been found?
                            onClick={handleNoteClick}
                        />

                    )
                });
            }) : null}
        </>
    )
}
export default FindUnisonNotes;
