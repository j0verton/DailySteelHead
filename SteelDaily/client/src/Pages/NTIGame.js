import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import NTIQuestionCard from "../components/NTIQuestionCard";


const NTIGame = () => {

    return (
        <div className="game-area">
            <div className="score-container">
                <ScoreDisplay />
            </div>
            <div className="card-area">
                <NTIQuestionCard />
            </div>

        </div>



    )


};
export default NTIGame;