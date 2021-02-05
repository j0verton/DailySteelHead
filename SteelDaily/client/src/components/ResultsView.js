import React, { useEffect, useState, useContext } from "react"
import { UserProfileContext } from "../providers/UserProfileProvider";
import ScoreDisplay from "./ScoreDisplay"

const ResultsView = ({ result, game }) => {
    const [userProfile, setUserProfile] = useState({})
    const { getToken, getCurrentUser } = useContext(UserProfileContext);

    useEffect(() => {
        setUserProfile(getCurrentUser())

    }, [])


    return (
        <>
            <h3>Great job taking the time to study</h3>
            <h2> {userProfile.firstName}!</h2>
            <h4>you got {result.outcomes.filter(Boolean).length} right out of 10 question</h4>
            <ScoreDisplay result={result} game={game} />
        </>
    )
}
export default ResultsView;
